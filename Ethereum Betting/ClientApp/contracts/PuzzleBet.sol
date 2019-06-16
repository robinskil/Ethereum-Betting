pragma solidity ^0.5.0;

import "./Bet.sol";

contract PuzzleBet is Bet {
    address public selfAddress;
    string apiCallAddress;

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
        selfAddress = address(this);
        //xs();
        bytes memory linkLeft = bytes("https://ethereumbetting.azurewebsites.net/api/SlidingPuzzleBet/GetWinners?addressPuzzleBet=");
        bytes memory linkRight = bytes(addressToString(address(this)));
        apiCallAddress = strConcat(string(linkLeft), string(linkRight));
        //emit TestEvent(addrToString(address(this)));
    }

    function addressToString(address _addr) public pure returns(string memory) {
        bytes32 value = bytes32(uint256(_addr));
        bytes memory alphabet = "0123456789abcdef";

        bytes memory str = new bytes(42);
        str[0] = '0';
        str[1] = 'x';
        for (uint i = 0; i < 20; i++) {
            str[2+i*2] = alphabet[uint8(value[i + 12] >> 4)];
            str[3+i*2] = alphabet[uint8(value[i + 12] & 0x0f)];
        }
        return string(str);
    }

    function xs() public payable {
        oraclize_query(bet.betLength,"URL", apiCallAddress);
    }

    function getWinnersApi() public payable {
        oraclize_setCustomGasPrice(4000000000);
        emit Log("called api");        
        emit Log(apiCallAddress);
        oraclize_query("URL", apiCallAddress,5000000);
        emit Log("finish calling api");
    }

    function __callback(bytes32 myid, string memory result) public {
        if (msg.sender != oraclize_cbAddress()) revert();
        emit TestEvent(result);
        bytes memory byteString = bytes(result);
        //Loop through result string
        //Set winners and split by "@"
        uint splitAmount = 0;
        bytes memory winnerAddress = new bytes(42);
        bool skipCharacter = false;
        emit Length(byteString.length);
        for(uint i = 0; i < byteString.length; i++){
            if(skipCharacter == true){
                skipCharacter = false;
            }
            else if(splitAmount < 42){
                winnerAddress[splitAmount] = byteString[i];
                splitAmount++;
            }
            if(splitAmount == 42){
                AddWinners(parseAddr(string(winnerAddress)));
                skipCharacter = true;
                winnerAddress = new bytes(42);
                splitAmount = 0;
            }
        }
        divideWinnings();
        emit Winners(bet.winners);
    }

    event TestEvent(string val);
    event Winner(string val);
    event Length(uint length);
    event Address(address betAdr);
    event Winners(address[] winners);
    event Log(string s);

    function TestAddWinners(string memory winners) public {
        //emit TestEvent(winners);
        bytes memory byteString = bytes(winners);
        //Loop through result string
        //Set winners and split by "@"
        uint splitAmount = 0;
        bytes memory winnerAddress = new bytes(42);
        bool skipCharacter = false;
        //emit Length(byteString.length);
        for(uint i = 0; i < byteString.length; i++){
            if(skipCharacter == true){
                skipCharacter = false;
            }
            else if(splitAmount < 42){
                winnerAddress[splitAmount] = byteString[i];
                splitAmount++;
            }
            if(splitAmount == 42){
                address winnerad = parseAddr(string(winnerAddress));
                if(userAlreadyJoined(winnerad) && !userAlreadyWinner(winnerad)){
                    AddWinners(winnerad);
                }
                skipCharacter = true;
                winnerAddress = new bytes(42);
                splitAmount = 0;
            }
        }
        divideWinnings();
        emit Winners(bet.winners);
    }

    function AddWinners(address winner) private {
        bet.winners.push(winner);
    }

    function divideWinnings() private {
        //There are winners
        uint amountWinning = 0;
        if(bet.winners.length > 0) {
            uint256 balance = getStoredBalance();
            while(balance % bet.winners.length != 0) {
                balance = balance - 1;
            }
            amountWinning = balance / bet.winners.length;
        }
        for(uint i = 0;i<bet.winners.length;i++) {
            pendingWithdrawals[bet.winners[i]] = amountWinning;
        }
    }
}