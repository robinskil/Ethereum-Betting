pragma solidity ^0.5.0;

import "./Bet.sol";

contract PuzzleBet is Bet {
    constructor (address _owner, uint _amount, uint _maxParticipators, bool _open, bool _friendsOnly, uint _betLength ) public  {
        //OAR = OraclizeAddrResolverI(0x6f485C8BF6fc43eA212E93BBF8ce046C7f1cb475);
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
        oraclize_query(bet.betLength,"URL", "");
    }

    function __callback(bytes32 myid, string memory result) public {
        if (msg.sender != oraclize_cbAddress()) revert();
        bytes memory byteString = bytes(result);
        //Loop through result string
        //Set winners and split by "@"
        uint splitAmount = 0;
        bytes memory winnerAddress = new bytes(42);
        for(uint i = 0; i < byteString.length; i++){
            if(byteString[i] == "@" && ( splitAmount == 42 || splitAmount == 44)){
                //Means the end of an address
                AddWinners(parseAddr(string(winnerAddress)));
                splitAmount = 0;
                winnerAddress = "";
            }
            winnerAddress[i] = byteString[i];
            splitAmount++;
        }
    }

    function TestAddWinners(string memory winners) public {
        bytes memory byteString = bytes(winners);
        //Loop through result string
        //Set winners and split by "@"
        uint splitAmount = 0;
        bytes memory winnerAddress = new bytes(42);
        for(uint i = 0; i < byteString.length; i++){
            if(byteString[i] == "@" && ( splitAmount == 42 || splitAmount == 44)){
                //Means the end of an address
                AddWinners(parseAddr(string(winnerAddress)));
                splitAmount = 0;
                winnerAddress = "";
            }
            winnerAddress[i] = byteString[i];
            splitAmount++;
        }
    }

    function AddWinners(address winner) private {
        bet.winners.push(winner);
    }

    function defineWinners() private returns(address[] memory){
        return bet.winners;
    }

    function divideWinnings() private {
        
    }
}