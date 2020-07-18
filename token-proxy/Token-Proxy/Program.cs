using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Threading;
using System.Threading.Tasks;
using Token_Proxy.Contract;

namespace Token_Proxy
{
    class Program
    {

        private static readonly string ROPSTEN_ADDRESS = "https://ropsten.infura.io/v3/fc6598ddab264c89a508cdb97d5398ea";
        private static string PrivateKey = "PrivateKey";

        public static string ContractAddress
        {
            get; set;
        }
        public static string ProxyAddress
        {
            get; set;
        }
        public static string MainAddress
        {
            get { return "0x64a3b626594d26336573211778ae786355d8b1e4"; }
        }
        static async Task Main(string[] args)
        {
            await DeployContractProxyAsync();
        }

        public static Web3 GetWeb3Object
        {
            get
            {
                var account = new Account(PrivateKey);
                var web3 = new Web3(account, ROPSTEN_ADDRESS);

                return web3;
            }
        }

        private static async Task DeployContractProxyAsync()
        {
            var dgtImplementation = new DGTImplementationDeployment();
            var dgtImplementationHandler = GetWeb3Object.Eth.GetContractDeploymentHandler<DGTImplementationDeployment>();
            var dgtImplementationReceiptDeployment = await dgtImplementationHandler.SendRequestAndWaitForReceiptAsync(dgtImplementation);

            ContractAddress = dgtImplementationReceiptDeployment.ContractAddress;

            Console.WriteLine(ContractAddress);
          

            var adminUpgradeabilityProxyDeployment = new AdminUpgradeabilityProxyDeployment();
            adminUpgradeabilityProxyDeployment.Implementation = dgtImplementationReceiptDeployment.ContractAddress;
            var adminUpgradeabilityProxyDeploymentHandler = GetWeb3Object.Eth.GetContractDeploymentHandler<AdminUpgradeabilityProxyDeployment>();
            var adminUpgradeabilityProxyReceiptDeployment = await adminUpgradeabilityProxyDeploymentHandler.SendRequestAndWaitForReceiptAsync(adminUpgradeabilityProxyDeployment);


            ProxyAddress = adminUpgradeabilityProxyReceiptDeployment.ContractAddress;

            Console.WriteLine(ProxyAddress);
          
            Thread.Sleep(2000);

            var contractHandler = GetWeb3Object.Eth.GetContractHandler(ProxyAddress);
            var changeAdminFunction = new ChangeAdminFunction();
            changeAdminFunction.NewAdmin = MainAddress;
            var changeAdminFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(changeAdminFunction);
            try
            {
                // Need proxy contract object of ContractAddress 
                contractHandler = GetWeb3Object.Eth.GetContractHandler(ContractAddress);
                var initializeFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync<InitializeFunction>();
                Console.WriteLine(initializeFunctionTxnReceipt.TransactionHash);
            }
            catch (Exception e)
            {
                var es = e.StackTrace;
            }
        }
    }
}
