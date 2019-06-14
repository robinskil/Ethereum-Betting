var factory = artifacts.require("./BettingFactory.sol");

module.exports = function (deployer) {
    deployer.deploy(factory);
};