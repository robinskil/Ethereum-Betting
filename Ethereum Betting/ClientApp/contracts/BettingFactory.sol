pragma solidity ^0.5.0;

import "./PuzzleBet.sol";
//Will be needed to create bets through composition.
//Our factory contract , this is deployed by us as developers.
contract BettingFactory {
    address[] public bets;

    //Instantiates a new PuzzleBet
    function createPuzzleBet(uint _value, uint _maxParticipators, bool _open, bool _friendsOnly, uint _betLength) public returns (address) {
        address betAddress = address(new PuzzleBet(msg.sender , _value , _maxParticipators , _open , _friendsOnly , _betLength));
        bets.push(betAddress);
        return betAddress;
    }

    //Gets all bets that are created
    function getAllBets() public view returns (address[] memory) {
        return bets;
    }

    //Gets all current bets that a user has.
    function getOwnedBets(address ownerAddress) public view returns (address[] memory) {
        address[] memory allBets = new address[](bets.length);
        uint256 currentIndice = 0;
        for (uint256 index = 0; index < bets.length; index++) {
            Bet bet = Bet(bets[index]);
            if (bet.getOwner() == ownerAddress) {
                allBets[currentIndice] = address(bet);
                currentIndice++;
            }
        }
        address[] memory ownedBets = new address[](currentIndice);
        for (uint256 index = 0 ; index < currentIndice; index++) {
            ownedBets[index] = allBets[index];
        }
        return ownedBets;
    }

    event Log(string s);

    //gets all bets ure participating in
    function getAllJoinedBets(address playerAddress) public returns (address[] memory) {
        emit Log("Start getting");
        address[] memory allBets = new address[](bets.length);
        uint256 currentIndice = 0;
        for (uint256 index = 0; index < bets.length; index++) {
            Bet bet = Bet(bets[index]);
            if (bet.userAlreadyJoined(playerAddress)) {
                allBets[currentIndice] = address(bet);
                currentIndice++;
            }
        }
        address[] memory joinedBets = new address[](currentIndice);
        for (uint256 index = 0 ; index < currentIndice; index++) {
            joinedBets[index] = allBets[index];
        }
        emit Log("End getting");
        return joinedBets;
    }
}
