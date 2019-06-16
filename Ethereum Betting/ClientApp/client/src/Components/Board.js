
import React from "react";
import Square from "../Components/Square";



export default class Board extends React.Component {
    render() {
        return (
            <div className="row">
                {this.props.cubes.map(cube => {
                    //console.log(cube.number);
                    return (
                        <div class="col-3 col-sm-3" style={{ marginTop: "5px", paddingRight: "5px", height: "150px" }}>
                            {cube.number == 0 ?
                                null :
                                <button className="btn btn-primary" style={{ width: "100%", height: "100%" }} onClick={() => this.props.callback(cube.x, cube.y)}>{cube.number}</button>
                            }
                        </div>
                    )
                })}
            </div>
        );
    }
}

