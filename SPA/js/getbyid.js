/* Instancia da Api*/
const api = new Api();

/*id do usuario a ser listado*/
const id = localStorage.getItem('userId');

/*Executa o metodo get da api buscando um usuário pelo id*/
function GetUser() {
    api.getUser(id)
    .then(res => {
        /*Cria uma lista com as informaçoes do usuario*/
        let output =
        `
            <ul class="list-group-flush">
                <li class="list-group-item">ID: ${res.id}</li>
                <li class="list-group-item">Nome: ${res.name}</li>
                <li class="list-group-item">E-mail: ${res.email}</li>
                <li class="list-group-item">Senha: ${res.password}</li>                     
            </ul>
        `
        /*Exibi na tela a lista criada*/
        document.querySelector('.user').innerHTML = output;
        document.querySelector('.name').innerText = res.name.toUpperCase();  
    })
    .catch(err => {
        console.log(err);
    })
}

document.addEventListener('DOMContentLoaded', GetUser);



