
import React from "react";
import Puzzle from "../Components/Puzzle";

class PuzzlePage extends React.Component {

    render() {

        return (
            <div>
                <Puzzle
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

export default PuzzlePage;