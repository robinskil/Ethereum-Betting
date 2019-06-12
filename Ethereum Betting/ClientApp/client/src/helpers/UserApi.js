export function handleResponse(res) {
    return res.json();
}

export async function CreateUser(Address, Password, Username){
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


export function setLoggedIn() {
    localStorage.setItem("loggedIn", "true");
}

export function IsAuthenticated(){
    return Boolean(localStorage.getItem("loggedIn"));
}

export function getToken() {
    return localStorage.getItem('claimsID');
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

export async function ChangePassword(Address, OldPassword, NewPassword){
    return fetch('api/user/changepassword', {
        method: 'POST',
        headers: {
            'Content-type': 'application/json'
        },
        body: JSON.stringify({
            Address: Address,
            OldPassword: OldPassword,
            NewPassword: NewPassword
        })
    })
    .then(handleResponse)
    .catch((err)=>console.log(err))
}

export async function DeleteUser(Address, Password){
    return fetch('api/user/delete', {
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