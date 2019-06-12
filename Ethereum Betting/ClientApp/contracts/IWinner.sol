pragma solidity ^0.5.0;

interface IWinner {
    struct Winners {address[] users;}
    function GetWinners() external;
    function AddWinner() external;
}