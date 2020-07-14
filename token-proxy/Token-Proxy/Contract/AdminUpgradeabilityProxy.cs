using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Token_Proxy.Contract
{
    public class AdminUpgradeabilityProxyConsole
    {
        public static void MainTest()
        {
            var url = "http://testchain.nethereum.com:8545";
            //var url = "https://mainnet.infura.io";
            var privateKey = "0x7580e7fb49df1c861f0050fae31c2224c6aba908e116b8da44ee8cd927b990b0";
            var account = new Nethereum.Web3.Accounts.Account(privateKey);
            var web3 = new Web3(account, url);
            var contractAddress = "0x.eee";
            /* Deployment 
           var adminUpgradeabilityProxyDeployment = new AdminUpgradeabilityProxyDeployment();
               adminUpgradeabilityProxyDeployment.Implementation = implementation;
           var transactionReceiptDeployment = await web3.Eth.GetContractDeploymentHandler<AdminUpgradeabilityProxyDeployment>().SendRequestAndWaitForReceiptAsync(adminUpgradeabilityProxyDeployment);
           var contractAddress = transactionReceiptDeployment.ContractAddress;
            */
            var contractHandler = web3.Eth.GetContractHandler(contractAddress);

            /** Function: upgradeTo**/
            /*
            var upgradeToFunction = new UpgradeToFunction();
            upgradeToFunction.NewImplementation = newImplementation;
            var upgradeToFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(upgradeToFunction);
            */


            /** Function: upgradeToAndCall**/
            /*
            var upgradeToAndCallFunction = new UpgradeToAndCallFunction();
            upgradeToAndCallFunction.NewImplementation = newImplementation;
            upgradeToAndCallFunction.Data = data;
            var upgradeToAndCallFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(upgradeToAndCallFunction);
            */


            /** Function: implementation**/
            /*
            var implementationFunctionReturn = await contractHandler.QueryAsync<ImplementationFunction, string>();
            */


            /** Function: changeAdmin**/
            /*
            var changeAdminFunction = new ChangeAdminFunction();
            changeAdminFunction.NewAdmin = newAdmin;
            var changeAdminFunctionTxnReceipt = await contractHandler.SendRequestAndWaitForReceiptAsync(changeAdminFunction);
            */


            /** Function: admin**/
            /*
            var adminFunctionReturn = await contractHandler.QueryAsync<AdminFunction, string>();
            */
        }

    }

    public partial class AdminUpgradeabilityProxyDeployment : AdminUpgradeabilityProxyDeploymentBase
    {
        public AdminUpgradeabilityProxyDeployment() : base(BYTECODE) { }
        public AdminUpgradeabilityProxyDeployment(string byteCode) : base(byteCode) { }
    }

    public class AdminUpgradeabilityProxyDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b5060405160208061080d83398101604081815291517f6f72672e7a657070656c696e6f732e70726f78792e696d706c656d656e74617482527f696f6e00000000000000000000000000000000000000000000000000000000006020830152915190819003602301902081906000805160206107ed8339815191521461009157fe5b6100a381640100000000610104810204565b50604080517f6f72672e7a657070656c696e6f732e70726f78792e61646d696e0000000000008152905190819003601a0190206000805160206107cd833981519152146100ec57fe5b6100fe336401000000006101c2810204565b506101dc565b600061011c826401000000006105ae6101d482021704565b15156101af57604080517f08c379a000000000000000000000000000000000000000000000000000000000815260206004820152603b60248201527f43616e6e6f742073657420612070726f787920696d706c656d656e746174696f60448201527f6e20746f2061206e6f6e2d636f6e747261637420616464726573730000000000606482015290519081900360840190fd5b506000805160206107ed83398151915255565b6000805160206107cd83398151915255565b6000903b1190565b6105e2806101eb6000396000f30060806040526004361061006c5763ffffffff7c01000000000000000000000000000000000000000000000000000000006000350416633659cfe681146100765780634f1ef286146100975780635c60da1b146100b75780638f283970146100e8578063f851a44014610109575b61007461011e565b005b34801561008257600080fd5b50610074600160a060020a0360043516610138565b61007460048035600160a060020a03169060248035908101910135610172565b3480156100c357600080fd5b506100cc6101ea565b60408051600160a060020a039092168252519081900360200190f35b3480156100f457600080fd5b50610074600160a060020a0360043516610227565b34801561011557600080fd5b506100cc610339565b610126610364565b610136610131610411565b610436565b565b61014061045a565b600160a060020a031633600160a060020a03161415610167576101628161047f565b61016f565b61016f61011e565b50565b61017a61045a565b600160a060020a031633600160a060020a031614156101dd5761019c8361047f565b30600160a060020a03163483836040518083838082843782019150509250505060006040518083038185875af19250505015156101d857600080fd5b6101e5565b6101e561011e565b505050565b60006101f461045a565b600160a060020a031633600160a060020a0316141561021c57610215610411565b9050610224565b61022461011e565b90565b61022f61045a565b600160a060020a031633600160a060020a0316141561016757600160a060020a03811615156102e557604080517f08c379a000000000000000000000000000000000000000000000000000000000815260206004820152603660248201527f43616e6e6f74206368616e6765207468652061646d696e206f6620612070726f60448201527f787920746f20746865207a65726f206164647265737300000000000000000000606482015290519081900360840190fd5b7f7e644d79422f17c01e4894b5f4f588d331ebfa28653d42ae832dc59e38c9798f61030e61045a565b60408051600160a060020a03928316815291841660208301528051918290030190a1610162816104c7565b600061034361045a565b600160a060020a031633600160a060020a0316141561021c5761021561045a565b61036c61045a565b600160a060020a031633141561040957604080517f08c379a000000000000000000000000000000000000000000000000000000000815260206004820152603260248201527f43616e6e6f742063616c6c2066616c6c6261636b2066756e6374696f6e20667260448201527f6f6d207468652070726f78792061646d696e0000000000000000000000000000606482015290519081900360840190fd5b610136610136565b7f7050c9e0f4ca769c69bd3a8ef740bc37934f8e2c036e5a723fd8ee048ed3f8c35490565b3660008037600080366000845af43d6000803e808015610455573d6000f35b3d6000fd5b7f10d6a54a4754c8869d6886b5f5d7fbfa5b4522237ea5c60d11bc4e7a1ff9390b5490565b610488816104eb565b60408051600160a060020a038316815290517fbc7cd75a20ee27fd9adebab32041f755214dbc6bffa90cc0225b39da2e5c2d3b9181900360200190a150565b7f10d6a54a4754c8869d6886b5f5d7fbfa5b4522237ea5c60d11bc4e7a1ff9390b55565b60006104f6826105ae565b151561058957604080517f08c379a000000000000000000000000000000000000000000000000000000000815260206004820152603b60248201527f43616e6e6f742073657420612070726f787920696d706c656d656e746174696f60448201527f6e20746f2061206e6f6e2d636f6e747261637420616464726573730000000000606482015290519081900360840190fd5b507f7050c9e0f4ca769c69bd3a8ef740bc37934f8e2c036e5a723fd8ee048ed3f8c355565b6000903b11905600a165627a7a723058207d34409da9a956ec4a00adb0105e7af3a389440ad43fa99793797bfd87a95a14002910d6a54a4754c8869d6886b5f5d7fbfa5b4522237ea5c60d11bc4e7a1ff9390b7050c9e0f4ca769c69bd3a8ef740bc37934f8e2c036e5a723fd8ee048ed3f8c3";
        public AdminUpgradeabilityProxyDeploymentBase() : base(BYTECODE) { }
        public AdminUpgradeabilityProxyDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_implementation", 1)]
        public virtual string Implementation { get; set; }
    }

    public partial class UpgradeToFunction : UpgradeToFunctionBase { }

    [Function("upgradeTo")]
    public class UpgradeToFunctionBase : FunctionMessage
    {
        [Parameter("address", "newImplementation", 1)]
        public virtual string NewImplementation { get; set; }
    }

    public partial class UpgradeToAndCallFunction : UpgradeToAndCallFunctionBase { }

    [Function("upgradeToAndCall")]
    public class UpgradeToAndCallFunctionBase : FunctionMessage
    {
        [Parameter("address", "newImplementation", 1)]
        public virtual string NewImplementation { get; set; }
        [Parameter("bytes", "data", 2)]
        public virtual byte[] Data { get; set; }
    }

    public partial class ImplementationFunction : ImplementationFunctionBase { }

    [Function("implementation", "address")]
    public class ImplementationFunctionBase : FunctionMessage
    {

    }

    public partial class ChangeAdminFunction : ChangeAdminFunctionBase { }

    [Function("changeAdmin")]
    public class ChangeAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "newAdmin", 1)]
        public virtual string NewAdmin { get; set; }
    }

    public partial class AdminFunction : AdminFunctionBase { }

    [Function("admin", "address")]
    public class AdminFunctionBase : FunctionMessage
    {

    }

    public partial class AdminChangedEventDTO : AdminChangedEventDTOBase { }

    [Event("AdminChanged")]
    public class AdminChangedEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousAdmin", 1, false)]
        public virtual string PreviousAdmin { get; set; }
        [Parameter("address", "newAdmin", 2, false)]
        public virtual string NewAdmin { get; set; }
    }

    public partial class UpgradedEventDTO : UpgradedEventDTOBase { }

    [Event("Upgraded")]
    public class UpgradedEventDTOBase : IEventDTO
    {
        [Parameter("address", "implementation", 1, false)]
        public virtual string Implementation { get; set; }
    }





    public partial class ImplementationOutputDTO : ImplementationOutputDTOBase { }

    [FunctionOutput]
    public class ImplementationOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class AdminOutputDTO : AdminOutputDTOBase { }

    [FunctionOutput]
    public class AdminOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

}
