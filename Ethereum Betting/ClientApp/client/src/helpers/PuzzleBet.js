export async function AddWinners(puzzleContract, address) {
    return await puzzleContract.AddWinners(address).call();
}