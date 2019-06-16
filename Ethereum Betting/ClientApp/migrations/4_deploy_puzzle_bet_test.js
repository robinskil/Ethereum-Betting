var PuzzleBet = artifacts.require("./PuzzleBet.sol");

module.exports = function (deployer) {
    deployer.deploy(PuzzleBet, "0x341b9290f9083D7f08882b0d311006564D2a35E7", 3, 3, true, true, 3);
};