const PuzzleBet = artifacts.require("./PuzzleBet.sol");

contract("PuzzleBet", accounts => {
    it("...should add the correct winner from a string", async () => {
        const simpleStorageInstance = await PuzzleBet.deployed();
        await simpleStorageInstance.join({ from: accounts[0], value: web3.utils.toWei("3", 'ether') });
        await simpleStorageInstance.TestAddWinners("0x341b9290f9083D7f08882b0d311006564D2a35E7", { from: accounts[0] });

        const storedData = await simpleStorageInstance.getWinners.call();
        assert.equal(storedData, "0x341b9290f9083D7f08882b0d311006564D2a35E7", "Not the same winners");
        console.log(storedData);
    });
    it("...should add the correct multiple winners from a string", async () => {
        const simpleStorageInstance = await PuzzleBet.deployed();
        // Set value of 89
        //await simpleStorageInstance.join({ from: accounts[0], value: web3.utils.toWei("3", 'ether') });
        await simpleStorageInstance.join({ from: accounts[1], value: web3.utils.toWei("3", 'ether') });
        await simpleStorageInstance.TestAddWinners("0x341b9290f9083D7f08882b0d311006564D2a35E7@0x01C4AD590009b3c54b3FCe3770D98DB04bBBcD8b", { from: accounts[0] });
        // Get stored value
        const storedData = await simpleStorageInstance.getWinners.call();
        assert.deepEqual(storedData, ['0x341b9290f9083D7f08882b0d311006564D2a35E7', '0x01C4AD590009b3c54b3FCe3770D98DB04bBBcD8b'], "Not the same winners");
        console.log(storedData);
    });
});