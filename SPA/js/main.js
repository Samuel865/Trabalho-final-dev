const api = new Api();
const btn = document.querySelector('#btn');
const tbody = document.querySelector('#tb');

document.addEventListener('DOMContentLoaded', GetUsers);

document.querySelector('#cadastrar').addEventListener('click', CreateUser);

function GetUsers() {
    api.getUSers()
        .then(res => {
            const data = res;
            let output = '';

            data.forEach(x => {
                output +=
                    `
                <tr class="texrt-dark">
                    <td>${x.id}</td>
                    <td>${x.name}</td>
                    <td>${x.email}</td>                   
                    <td>
                        <a href="#" onclick="api.deleteUser(${x.id})"><i class="fas fa-trash-alt"></i></a>
                        <a href="#" class="p-4"><i class="fas fa-info-circle"></i></a>
                        <a href="#"><i class="fas fa-edit"></i></a>
                    </td>                   
                </tr>
             `
            })
            tbody.innerHTML = output;
        })
        .catch(err => console.log(err))
}

function CreateUser() {
    const nome = document.querySelector('#nome').value;
    const email = document.querySelector('#email').value;
    const usuario = document.querySelector('#usuario').value;
    const senha = document.querySelector('#senha').value;
    
    const user = {
        name: nome,
        email: email,
        username: usuario,
        password: senha
    };
    console.log(user);
    api.postUser(user); 
    window.location.href="http://127.0.0.1:5500/userlist.html";
}



