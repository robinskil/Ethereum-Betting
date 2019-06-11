export function handleResponse(res) {
    return res.json();
}

export async function CreatUser(Address, Password, Username){
    return fetch('api/user/register', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            Address: Address,
            Password: Password,
            Username: Username
        })
    })
    .then(handleResponse)
    .catch((err)=>console.log(err))
}

export async function LoginUser(Address, Password){
    return fetch('api/user/login', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            Address: Address,
            Password: Password
        })
    })
    .then(handleResponse)
    .catch((err)=>console.log(err))
}