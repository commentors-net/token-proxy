using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Token_Proxy
{
    class Program
    {

        private static readonly string ROPSTEN_ADDRESS = "https://ropsten.infura.io/v3/fc6598ddab264c89a508cdb97d5398ea";
        private static string PrivateKey = "PrivateKey";
        private static string AbiContract = @"abi-contract";
        private static string ByteCodeContract = "byte-code-contract";

        private static string AbiProxy = @"abi-proxy";
        private static string ByteCodeProxy = "byte-code-proxy";

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
            var TranHash = await GetWeb3Object.Eth.DeployContract.SendRequestAsync
                (AbiContract, ByteCodeContract, MainAddress, new Nethereum.Hex.HexTypes.HexBigInteger("470000"));
            if (TranHash != null)
            {
                try
                {
                    var receipt = await GetWeb3Object.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(TranHash);

                    while (receipt == null)
                    {
                        Thread.Sleep(5000);
                        receipt = await GetWeb3Object.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(TranHash);
                    }

                    ContractAddress = receipt.ContractAddress;
                    Console.WriteLine("Contract " + ContractAddress);
                    // Deploying Proxy

                    var TranHash2 = await GetWeb3Object.Eth.DeployContract.SendRequestAsync
                        (AbiProxy, ByteCodeProxy, MainAddress, new Nethereum.Hex.HexTypes.HexBigInteger("470000"));

                    while (receipt == null)
                    {
                        Thread.Sleep(5000);
                        receipt = await GetWeb3Object.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(TranHash2);
                    }

                    ProxyAddress = receipt.ContractAddress;
                    Console.WriteLine("Proxy " + ProxyAddress);
                }

                catch (Exception ee)
                {
                    Console.WriteLine(ee.StackTrace);
                }
            }
        }
    }
}
