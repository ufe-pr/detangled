using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Detangled.Contracts.Detangled.ContractDefinition;

namespace Detangled.Contracts.Detangled
{
    public partial class DetangledService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, DetangledDeployment detangledDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<DetangledDeployment>().SendRequestAndWaitForReceiptAsync(detangledDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, DetangledDeployment detangledDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<DetangledDeployment>().SendRequestAsync(detangledDeployment);
        }

        public static async Task<DetangledService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, DetangledDeployment detangledDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, detangledDeployment, cancellationTokenSource);
            return new DetangledService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public DetangledService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> BETA_TESTERQueryAsync(BETA_TESTERFunction bETA_TESTERFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BETA_TESTERFunction, BigInteger>(bETA_TESTERFunction, blockParameter);
        }

        
        public Task<BigInteger> BETA_TESTERQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BETA_TESTERFunction, BigInteger>(null, blockParameter);
        }

        public Task<byte[]> DEFAULT_ADMIN_ROLEQueryAsync(DEFAULT_ADMIN_ROLEFunction dEFAULT_ADMIN_ROLEFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DEFAULT_ADMIN_ROLEFunction, byte[]>(dEFAULT_ADMIN_ROLEFunction, blockParameter);
        }

        
        public Task<byte[]> DEFAULT_ADMIN_ROLEQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DEFAULT_ADMIN_ROLEFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> MINTER_ROLEQueryAsync(MINTER_ROLEFunction mINTER_ROLEFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MINTER_ROLEFunction, byte[]>(mINTER_ROLEFunction, blockParameter);
        }

        
        public Task<byte[]> MINTER_ROLEQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MINTER_ROLEFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> PAUSER_ROLEQueryAsync(PAUSER_ROLEFunction pAUSER_ROLEFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PAUSER_ROLEFunction, byte[]>(pAUSER_ROLEFunction, blockParameter);
        }

        
        public Task<byte[]> PAUSER_ROLEQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PAUSER_ROLEFunction, byte[]>(null, blockParameter);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string account, BigInteger id, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Account = account;
                balanceOfFunction.Id = id;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<List<BigInteger>> BalanceOfBatchQueryAsync(BalanceOfBatchFunction balanceOfBatchFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfBatchFunction, List<BigInteger>>(balanceOfBatchFunction, blockParameter);
        }

        
        public Task<List<BigInteger>> BalanceOfBatchQueryAsync(List<string> accounts, List<BigInteger> ids, BlockParameter blockParameter = null)
        {
            var balanceOfBatchFunction = new BalanceOfBatchFunction();
                balanceOfBatchFunction.Accounts = accounts;
                balanceOfBatchFunction.Ids = ids;
            
            return ContractHandler.QueryAsync<BalanceOfBatchFunction, List<BigInteger>>(balanceOfBatchFunction, blockParameter);
        }

        public Task<string> BurnRequestAsync(BurnFunction burnFunction)
        {
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BurnFunction burnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnRequestAsync(string account, BigInteger id, BigInteger value)
        {
            var burnFunction = new BurnFunction();
                burnFunction.Account = account;
                burnFunction.Id = id;
                burnFunction.Value = value;
            
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(string account, BigInteger id, BigInteger value, CancellationTokenSource cancellationToken = null)
        {
            var burnFunction = new BurnFunction();
                burnFunction.Account = account;
                burnFunction.Id = id;
                burnFunction.Value = value;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnBatchRequestAsync(BurnBatchFunction burnBatchFunction)
        {
             return ContractHandler.SendRequestAsync(burnBatchFunction);
        }

        public Task<TransactionReceipt> BurnBatchRequestAndWaitForReceiptAsync(BurnBatchFunction burnBatchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnBatchFunction, cancellationToken);
        }

        public Task<string> BurnBatchRequestAsync(string account, List<BigInteger> ids, List<BigInteger> values)
        {
            var burnBatchFunction = new BurnBatchFunction();
                burnBatchFunction.Account = account;
                burnBatchFunction.Ids = ids;
                burnBatchFunction.Values = values;
            
             return ContractHandler.SendRequestAsync(burnBatchFunction);
        }

        public Task<TransactionReceipt> BurnBatchRequestAndWaitForReceiptAsync(string account, List<BigInteger> ids, List<BigInteger> values, CancellationTokenSource cancellationToken = null)
        {
            var burnBatchFunction = new BurnBatchFunction();
                burnBatchFunction.Account = account;
                burnBatchFunction.Ids = ids;
                burnBatchFunction.Values = values;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnBatchFunction, cancellationToken);
        }

        public Task<byte[]> GetRoleAdminQueryAsync(GetRoleAdminFunction getRoleAdminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        
        public Task<byte[]> GetRoleAdminQueryAsync(byte[] role, BlockParameter blockParameter = null)
        {
            var getRoleAdminFunction = new GetRoleAdminFunction();
                getRoleAdminFunction.Role = role;
            
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        public Task<string> GetRoleMemberQueryAsync(GetRoleMemberFunction getRoleMemberFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRoleMemberFunction, string>(getRoleMemberFunction, blockParameter);
        }

        
        public Task<string> GetRoleMemberQueryAsync(byte[] role, BigInteger index, BlockParameter blockParameter = null)
        {
            var getRoleMemberFunction = new GetRoleMemberFunction();
                getRoleMemberFunction.Role = role;
                getRoleMemberFunction.Index = index;
            
            return ContractHandler.QueryAsync<GetRoleMemberFunction, string>(getRoleMemberFunction, blockParameter);
        }

        public Task<BigInteger> GetRoleMemberCountQueryAsync(GetRoleMemberCountFunction getRoleMemberCountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRoleMemberCountFunction, BigInteger>(getRoleMemberCountFunction, blockParameter);
        }

        
        public Task<BigInteger> GetRoleMemberCountQueryAsync(byte[] role, BlockParameter blockParameter = null)
        {
            var getRoleMemberCountFunction = new GetRoleMemberCountFunction();
                getRoleMemberCountFunction.Role = role;
            
            return ContractHandler.QueryAsync<GetRoleMemberCountFunction, BigInteger>(getRoleMemberCountFunction, blockParameter);
        }

        public Task<string> GrantRoleRequestAsync(GrantRoleFunction grantRoleFunction)
        {
             return ContractHandler.SendRequestAsync(grantRoleFunction);
        }

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(GrantRoleFunction grantRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(grantRoleFunction, cancellationToken);
        }

        public Task<string> GrantRoleRequestAsync(byte[] role, string account)
        {
            var grantRoleFunction = new GrantRoleFunction();
                grantRoleFunction.Role = role;
                grantRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(grantRoleFunction);
        }

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var grantRoleFunction = new GrantRoleFunction();
                grantRoleFunction.Role = role;
                grantRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(grantRoleFunction, cancellationToken);
        }

        public Task<bool> HasRoleQueryAsync(HasRoleFunction hasRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        
        public Task<bool> HasRoleQueryAsync(byte[] role, string account, BlockParameter blockParameter = null)
        {
            var hasRoleFunction = new HasRoleFunction();
                hasRoleFunction.Role = role;
                hasRoleFunction.Account = account;
            
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        public Task<bool> IsApprovedForAllQueryAsync(IsApprovedForAllFunction isApprovedForAllFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        
        public Task<bool> IsApprovedForAllQueryAsync(string account, string @operator, BlockParameter blockParameter = null)
        {
            var isApprovedForAllFunction = new IsApprovedForAllFunction();
                isApprovedForAllFunction.Account = account;
                isApprovedForAllFunction.Operator = @operator;
            
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        public Task<string> MintRequestAsync(MintFunction mintFunction)
        {
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(MintFunction mintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(string to, BigInteger id, BigInteger amount, byte[] data)
        {
            var mintFunction = new MintFunction();
                mintFunction.To = to;
                mintFunction.Id = id;
                mintFunction.Amount = amount;
                mintFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(string to, BigInteger id, BigInteger amount, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var mintFunction = new MintFunction();
                mintFunction.To = to;
                mintFunction.Id = id;
                mintFunction.Amount = amount;
                mintFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> MintBatchRequestAsync(MintBatchFunction mintBatchFunction)
        {
             return ContractHandler.SendRequestAsync(mintBatchFunction);
        }

        public Task<TransactionReceipt> MintBatchRequestAndWaitForReceiptAsync(MintBatchFunction mintBatchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintBatchFunction, cancellationToken);
        }

        public Task<string> MintBatchRequestAsync(string to, List<BigInteger> ids, List<BigInteger> amounts, byte[] data)
        {
            var mintBatchFunction = new MintBatchFunction();
                mintBatchFunction.To = to;
                mintBatchFunction.Ids = ids;
                mintBatchFunction.Amounts = amounts;
                mintBatchFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(mintBatchFunction);
        }

        public Task<TransactionReceipt> MintBatchRequestAndWaitForReceiptAsync(string to, List<BigInteger> ids, List<BigInteger> amounts, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var mintBatchFunction = new MintBatchFunction();
                mintBatchFunction.To = to;
                mintBatchFunction.Ids = ids;
                mintBatchFunction.Amounts = amounts;
                mintBatchFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintBatchFunction, cancellationToken);
        }

        public Task<string> PauseRequestAsync(PauseFunction pauseFunction)
        {
             return ContractHandler.SendRequestAsync(pauseFunction);
        }

        public Task<string> PauseRequestAsync()
        {
             return ContractHandler.SendRequestAsync<PauseFunction>();
        }

        public Task<TransactionReceipt> PauseRequestAndWaitForReceiptAsync(PauseFunction pauseFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(pauseFunction, cancellationToken);
        }

        public Task<TransactionReceipt> PauseRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<PauseFunction>(null, cancellationToken);
        }

        public Task<bool> PausedQueryAsync(PausedFunction pausedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PausedFunction, bool>(pausedFunction, blockParameter);
        }

        
        public Task<bool> PausedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PausedFunction, bool>(null, blockParameter);
        }

        public Task<string> RenounceRoleRequestAsync(RenounceRoleFunction renounceRoleFunction)
        {
             return ContractHandler.SendRequestAsync(renounceRoleFunction);
        }

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(RenounceRoleFunction renounceRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceRoleFunction, cancellationToken);
        }

        public Task<string> RenounceRoleRequestAsync(byte[] role, string account)
        {
            var renounceRoleFunction = new RenounceRoleFunction();
                renounceRoleFunction.Role = role;
                renounceRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(renounceRoleFunction);
        }

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var renounceRoleFunction = new RenounceRoleFunction();
                renounceRoleFunction.Role = role;
                renounceRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceRoleFunction, cancellationToken);
        }

        public Task<string> RevokeRoleRequestAsync(RevokeRoleFunction revokeRoleFunction)
        {
             return ContractHandler.SendRequestAsync(revokeRoleFunction);
        }

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(RevokeRoleFunction revokeRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeRoleFunction, cancellationToken);
        }

        public Task<string> RevokeRoleRequestAsync(byte[] role, string account)
        {
            var revokeRoleFunction = new RevokeRoleFunction();
                revokeRoleFunction.Role = role;
                revokeRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(revokeRoleFunction);
        }

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var revokeRoleFunction = new RevokeRoleFunction();
                revokeRoleFunction.Role = role;
                revokeRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeRoleFunction, cancellationToken);
        }

        public Task<string> SafeBatchTransferFromRequestAsync(SafeBatchTransferFromFunction safeBatchTransferFromFunction)
        {
             return ContractHandler.SendRequestAsync(safeBatchTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeBatchTransferFromRequestAndWaitForReceiptAsync(SafeBatchTransferFromFunction safeBatchTransferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeBatchTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeBatchTransferFromRequestAsync(string from, string to, List<BigInteger> ids, List<BigInteger> amounts, byte[] data)
        {
            var safeBatchTransferFromFunction = new SafeBatchTransferFromFunction();
                safeBatchTransferFromFunction.From = from;
                safeBatchTransferFromFunction.To = to;
                safeBatchTransferFromFunction.Ids = ids;
                safeBatchTransferFromFunction.Amounts = amounts;
                safeBatchTransferFromFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(safeBatchTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeBatchTransferFromRequestAndWaitForReceiptAsync(string from, string to, List<BigInteger> ids, List<BigInteger> amounts, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeBatchTransferFromFunction = new SafeBatchTransferFromFunction();
                safeBatchTransferFromFunction.From = from;
                safeBatchTransferFromFunction.To = to;
                safeBatchTransferFromFunction.Ids = ids;
                safeBatchTransferFromFunction.Amounts = amounts;
                safeBatchTransferFromFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeBatchTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFromFunction safeTransferFromFunction)
        {
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFromFunction safeTransferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger id, BigInteger amount, byte[] data)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.Id = id;
                safeTransferFromFunction.Amount = amount;
                safeTransferFromFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger id, BigInteger amount, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.Id = id;
                safeTransferFromFunction.Amount = amount;
                safeTransferFromFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(SetApprovalForAllFunction setApprovalForAllFunction)
        {
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(SetApprovalForAllFunction setApprovalForAllFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(string @operator, bool approved)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(string @operator, bool approved, CancellationTokenSource cancellationToken = null)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        public Task<string> UnpauseRequestAsync(UnpauseFunction unpauseFunction)
        {
             return ContractHandler.SendRequestAsync(unpauseFunction);
        }

        public Task<string> UnpauseRequestAsync()
        {
             return ContractHandler.SendRequestAsync<UnpauseFunction>();
        }

        public Task<TransactionReceipt> UnpauseRequestAndWaitForReceiptAsync(UnpauseFunction unpauseFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(unpauseFunction, cancellationToken);
        }

        public Task<TransactionReceipt> UnpauseRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<UnpauseFunction>(null, cancellationToken);
        }

        public Task<string> UriQueryAsync(UriFunction uriFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UriFunction, string>(uriFunction, blockParameter);
        }

        
        public Task<string> UriQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var uriFunction = new UriFunction();
                uriFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<UriFunction, string>(uriFunction, blockParameter);
        }
    }
}
