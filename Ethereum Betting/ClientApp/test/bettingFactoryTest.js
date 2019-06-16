const BettingFactory = artifacts.require("./BettingFactory.sol");

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}


contract("BettingFactory", accounts => {
    it("...should add the correct multiple winners from the api", async () => {
        const bettingFactoryInstance = await BettingFactory.deployed();
        // Set value of 89
        const betAddress = await bettingFactoryInstance.createPuzzleBet(3, 3, true, true, 1);
        console.log(betAddress);
        await sleep(20000);
        assert.equal(1, 2, "failed");
        // await simpleStorageInstance.join({ from: accounts[0], value: web3.utils.toWei("3", 'ether') });
        // await simpleStorageInstance.join({ from: accounts[1], value: web3.utils.toWei("3", 'ether') });
        // //await simpleStorageInstance.TestAddWinners("0x341b9290f9083D7f08882b0d311006564D2a35E7@0x01C4AD590009b3c54b3FCe3770D98DB04bBBcD8b", { from: accounts[0] });
        // //await simpleStorageInstance.getWinnersApi();
        // await sleep(20000).then(async () => {
        //     // Get stored value
        //     const storedData = await simpleStorageInstance.getWinners.call();
        //     assert.deepEqual(storedData, ['0x341b9290f9083D7f08882b0d311006564D2a35E7', '0x01C4AD590009b3c54b3FCe3770D98DB04bBBcD8b'], "Not the same winners");
        //     console.log(storedData);
        // });
    });
})