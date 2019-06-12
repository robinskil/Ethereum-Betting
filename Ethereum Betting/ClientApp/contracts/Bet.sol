pragma solidity ^0.5.0;

//TODO import oracles through oraclize
import "./oraclizeAPI.sol";

contract Bet is usingOraclize {

    struct BetStruct {
        //time of creation of the bet
        uint creationTime;
        //betting length in days.
        uint betLength;
        address owner;
        address[] participators;
        //Winners should be defined through the IWinner interface
        address[] winners;
        uint betAmount;
        uint maxParticipators;
        bool open;
        bool friendsOnly;
        bool finished;
    }
    BetStruct bet;
        modifier onlyOwner {
        require(
            msg.sender == bet.owner,
            "Only owner can call this function."
        );
        _;
    }

    //Guard to define whether a bet has finished.
    modifier betFinished{
        require(bet.finished == true,"Bet has already finished");
        _;
    }

    //guard to define whether a sender is participating.
    modifier participating{
        require(userAlreadyJoined(msg.sender) == true,"You have to join this bet first.");
        _;
    }
    
    //todo check if user is already in list....
    function join() public payable{
        require(msg.value == bet.betAmount * 1 ether,"Requires Ether.");
        require(bet.open == true,"Bet is not open");
        require(userAlreadyJoined(msg.sender) == false,"User has already joined this bet");
        bet.participators.push(msg.sender);
    }

    function userAlreadyJoined(address userAddress) private view returns (bool) {
        for (uint index = 0 ; index < bet.participators.length; index++) {
            if(bet.participators[index] == userAddress) return true;
        }
        return false;
    }

    function checkJoined() public view returns(bool) {
        return userAlreadyJoined(msg.sender);
    }

    function isOpen() public view returns(bool) {
        return bet.open;
    }

    function friendsOnly() public onlyOwner view returns(bool) {
        return bet.friendsOnly;
    }

    function finished() public view returns(bool) {
        return bet.finished;
    }

    function getParticipators() public view returns  (address[] memory) {
        return bet.participators;
    }

    function getBetAmount() public view returns (uint) {
        return bet.betAmount;
    }

    function getOwner() public view returns (address) {
        return bet.owner;
    }

    function getStoredBalance() public view returns (uint256) {
        return address(this).balance;
    }
    
    //Add modifier
    function getWinners() public betFinished view returns(address[] memory) {
        return bet.winners;
    }

    function getCreationTime() public view returns(uint) {
        return bet.creationTime;
    }

    //returns time left in seconds for bet to end
    function timeLeft() public view returns(uint) {
        return (bet.creationTime - now) / (bet.betLength * 1 minutes);
    }
    
    /*ABSTRACT FUNCTIONS*/
    //Functions that need to be implemented by inherited contracts.
    function defineWinners() private returns (address[] memory);
    function divideWinnings() private;
}