import React from "react";
import "../css/Square.css";

function Square(props) {
    return (
        <button onClick={props.onClick}
            className="col"
            style={{
                fontSize: props.cubeSize / 3,
                fontWeight: "bold",
                height: "200px",
                width: "100px",
                borderRadius: 4,
                backgroundColor:
                    props.cube.number === props.level * props.level
                        ? "#faf8ef"
                        : props.cube.number === props.cube.position
                            ? "#9dc9cc"
                            : "#e2d1ae",
                color:
                    props.cube.number === props.level * props.level
                        ? "#faf8ef"
                        : "black",
            }}
        >
            {props.cube.number.toString() === "" ? "        " : props.cube.number.toString()}
        </button>
    );
}

export default Square;