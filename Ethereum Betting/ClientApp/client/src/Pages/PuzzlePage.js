
import React from "react";
import Board from "../Components/Board";
import "../css/Board.css";

class PuzzlePage extends React.Component {
    constructor(props) {
        super(props);
        console.log("betAddress: " + this.props.match.params.betAddress);
    }
    render() {
        return (
            <div>
                <Puzzle
                    web3={this.props.web3}
                    betAddress={this.props.match.params.betAddress}
                    level="4"
                    height={window.innerHeight}
                    width={window.innerWidth}
                    moves="0"
                    targetMoves="0"
                />
            </div>
        );
    }
}

class Puzzle extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            loading: true,
            level: Number(props.level),
            height: props.height,
            width: props.width,
            puzzle: [],
            cubes: null
        };
    }
    componentDidMount = async () => {
        const acc = await this.props.web3.eth.getAccounts();
        const betAddress = this.props.betAddress;
        fetch('../api/SlidingPuzzleBet/GetPuzzle?addressUser=' + acc[0] + '&addressBet=' + betAddress)
            .then(async (res) => {
                this.setState({ puzzle: await res.json() });
                console.log("Array is: ");
                console.log(this.state.puzzle);
                this.setState({ cubes: initCubes(this.state.puzzle) });
                console.log(this.state.cubes);
            });
    }
    handleClick = async (x, y) => {
        //do request to server
        console.log(x, y);
        const acc = await this.props.web3.eth.getAccounts();
        fetch('../api/SlidingPuzzleBet/MakeMove', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({
                AddressUser: acc[0],
                AddressBet: this.props.betAddress,
                x: y,
                y: x
            })
        })
            .then(async (res) => {
                if (res.ok) {
                    await this.setPuzzle();
                }
            });
    }

    setPuzzle = async () => {
        const acc = await this.props.web3.eth.getAccounts();
        const betAddress = this.props.betAddress;
        fetch('../api/SlidingPuzzleBet/GetPuzzle?addressUser=' + acc[0] + '&addressBet=' + betAddress)
            .then(async (res) => {
                this.setState({ puzzle: await res.json() });
                this.setState({ cubes: initCubes(this.state.puzzle) });
            });
    }

    render() {
        const cubes = this.state.cubes;
        const level = this.state.level;
        const cubeSize =
            (this.state.height / 2 < this.state.width
                ? this.state.height / 2
                : this.state.width) /
            (level + 1);
        return (

            <div>
                {this.state.cubes == null ? <div></div> :
                    <div>
                        <div className="container">
                            <h3>Can you solve it?</h3>
                        </div>
                        <div className="container">
                            <div className="board">
                                <Board
                                    cubes={cubes}
                                    level={level}
                                    cubeSize={cubeSize}
                                    callback={this.handleClick}
                                />
                            </div>
                        </div>
                    </div>
                }

            </div>
        );
    }
}
function initCubes(array2d) {
    var cubes = [];
    for (let i = 0; i < 4; i++) {
        for (let j = 0; j < 4; j++) {
            cubes.push({
                number: array2d[i][j],
                x: j,
                y: i
            });
        }
    }
    return cubes;
}

//function moveCube(cubes, level, i) {
//    var spaceCubePos = cubes.find(x => x.number === level * level).position;
//    // vertical move
//    if (spaceCubePos % level === (i + 1) % level) {
//        //move up
//        if (i + 1 > spaceCubePos) {
//            for (var j = spaceCubePos + level; j <= i + 1; j = j + level) {
//                swapCubes(cubes, level, j);
//            }
//        } else {
//            for (var k = spaceCubePos - level; k >= i + 1; k = k - level) {
//                swapCubes(cubes, level, k);
//            }
//        }
//    }
//    //horizontal move
//    var tmpCubes = cubes.slice();
//    while (tmpCubes.length) {
//        var row = tmpCubes.splice(0, level);
//         console.log(row);
//        if (
//            row.find(x => x.position === spaceCubePos) &&
//            row.find(x => x.position === i + 1)
//        ) {
//            //move right
//            if (i + 1 < spaceCubePos) {
//                for (j = spaceCubePos - 1; j >= i + 1; j--) {
//                    swapCubes(cubes, level, j);
//                }
//            } else {
//                for (k = spaceCubePos + 1; k <= i + 1; k++) {
//                    swapCubes(cubes, level, k);
//                }
//            }
//        }
//    }
//}

//function checkIfWon(cubes, level) {
//    var anyCubesLeft = cubes.find(
//        x => x.position !== x.number && x.number !== level * level
//    );
//    return !anyCubesLeft ? true : false;
//}


//function swapCubes(cubes, level, cubePos) {
//    var spaceCube = cubes.find(x => x.number === level * level);
//    if (
//        spaceCube.position - level === cubePos ||
//        (spaceCube.position - 1 === cubePos && spaceCube.position % level !== 1) ||
//        (spaceCube.position + 1 === cubePos && spaceCube.position % level !== 0) ||
//        spaceCube.position + level === cubePos
//    ) {
//        var tmpPlayerNo = cubes[cubePos - 1].number;
//        cubes[cubePos - 1].number = spaceCube.number;
//        cubes[spaceCube.position - 1].number = tmpPlayerNo;
//    }
//}
export default PuzzlePage;