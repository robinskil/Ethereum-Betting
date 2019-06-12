pragma solidity ^0.5.0;

import "./Bet.sol";
import "./strings.sol";

contract PuzzleBet is Bet {
    
    constructor (address _owner, uint _amount, uint _maxParticipators, bool _open, bool _friendsOnly, uint _betLength ) public  {
        OAR = OraclizeAddrResolverI(0x6f485C8BF6fc43eA212E93BBF8ce046C7f1cb475);
        require(_betLength > 0 && _maxParticipators <= 64 && _maxParticipators > 0,"Failed to supply correct input");
        bet.creationTime = now;
        bet.owner = _owner;
        bet.betAmount = _amount;
        bet.maxParticipators = _maxParticipators;
        bet.open = _open;
        bet.friendsOnly = _friendsOnly;
        bet.finished = false;
        bet.betLength = (1 minutes * _betLength);
        //xs();
    }

    function xs() public payable {
        oraclize_query(bet.betLength,"URL", "random number between 1 and 10");
    }

    function __callback(bytes32 myid, string memory result) public {
        if (msg.sender != oraclize_cbAddress()) revert();
        //randomNumber = parseInt(result);
        //after the number has been decided , the winners will be decided.
        //TODO???
        //defineWinners();
        //emit LogRandomNumber(result);
    }
    function SetWinners(address[] memory winners) private {
        bet.winners = winners;
    }
}