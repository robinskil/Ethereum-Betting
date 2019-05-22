import { METHODS } from "http";

export async function CreatUser(Address, Password){
    fetch('api/user/register', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            Address: Address,
            Password: Password
        })
    }).then((res) => res.json())
    .then((data) =>  console.log(data))
    .catch((err)=>console.log(err))
}

export async function LoginUser(Address, Password){
    fetch('api/user/login', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            Address: Address,
            Password: Password
        })
    }).then((res) => res.json())
    .then((data) =>  console.log(data))
    .catch((err)=>console.log(err))
}