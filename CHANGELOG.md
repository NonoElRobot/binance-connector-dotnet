# Changelog

## 1.1.0 - 2022-01-19
### Added
- New endpoints for BSwap
  - GET /sapi/v1/bswap/poolConfigure to get pool configure
  - GET /sapi/v1/bswap/addLiquidityPreview to get add liquidity preview
  - GET /sapi/v1/margin/isolated/accountLimit to get remove liquidity preview
  - GET /sapi/v1/bswap/unclaimedRewards to get unclaimed rewards record.
  - POST /sapi/v1/bswap/claimRewards to claim swap rewards or liquidity rewards.
  - GET /sapi/v1/bswap/claimedHistory to get history of claimed rewards.

- New endpoints for Trade:
  - GET api/v3/rateLimit/order added

- New endpoint for Crypto Loans
  - GET /sapi/v1/loan/income

- New endpoint for Pay
  - GET /sapi/v1/pay/transactions to support user query Pay trade history

- New endpoint for Convert
  - GET /sapi/v1/convert/tradeFlow to support user query convert trade history records

- New endpoint for Rebate
  - GET /sapi/v1/rebate/taxQuery to support user query spot rebate history records

- New endpoint for Margin
  - GET /sapi/v1/margin/crossMarginData to get cross margin fee data collection
  - GET /sapi/v1/margin/isolatedMarginData to get isolated margin fee data collection
  - GET /sapi/v1/margin/isolatedMarginTier to get isolated margin tier data collection

- New endpoints for NFT
  - GET /sapi/v1/nft/history/transactions to get NFT transaction history
  - GET /sapi/v1/nft/history/deposit to get NFT deposit history
  - GET /sapi/v1/nft/history/withdraw to get NFT withdraw history
  - GET /sapi/v1/nft/user/getAsset to get NFT asset

- New endpoint for Mining
  - GET /sapi/v1/mining/payment/uid to get Mining account earning.

- New endpoints for Sub-Account
  - POST /sapi/v1/sub-account/subAccountApi/ipRestriction to support master account enable and disable IP restriction for a sub-account API Key
  - POST /sapi/v1/sub-account/subAccountApi/ipRestriction/ipList to support master account add IP list for a sub-account API Key
  - GET /sapi/v1/account/apiRestrictions/ipRestriction to support master account query IP restriction for a sub-account API Key
  - DELETE /sapi/v1/account/apiRestrictions/ipRestriction/ipList to support master account delete IP list for a sub-account API Key

- Issue templates
  - Added templates for bug report and documentation changes 

- Actions
  - Added release action
  - Added multi-framework distributable build tests

### Updated
- Updated endpoints for Sub-Account
  - New parameter clientTranId added in POST /sapi/v1/sub-account/universalTransfer and GET /sapi/v1/sub-account/universalTransfer to support custom transfer id

- Updated endpoint for Wallet and Futures
  - GET /sapi/v1/asset/transfer
  - GET /sapi/v1/futures/transfer
  - GET /sapi/v1/accountSnapshot
  - The query time range of both endpoints are shortened to support data query within the last 6 months only, where startTime does not support selecting a timestamp beyond 6 months.
If you do not specify startTime and endTime, the data of the last 7 days will be returned by default.

- Updated endpoints for Wallet
  - New parameter walletType added in POST /sapi/v1/capital/withdraw/apply

- Updated endpoints for Margin
  - Removed out limit from GET /sapi/v1/margin/interestRateHistory
  - As the Mining account is merged into Funding account, transfer types MAIN_MINING, MINING_MAIN, MINING_UMFUTURE, MARGIN_MINING, and MINING_MARGIN will be discontinued in Universal Transfer endpoint POST /sapi/v1/asset/transfer on January 05, 2022 08:00 AM UTC

- Resolved lint warnings

- Improved Http Exceptions

## 1.0.1 - 2022-01-10

### Added
- Github CI format & unit tests actions
- Unit tests for enum models

### Fixed
- Enum query string serialisation
