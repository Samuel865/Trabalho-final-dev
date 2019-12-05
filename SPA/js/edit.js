/*Instancia da Classe Api*/
const api = new Api();

/*Captura os elementos da DOM*/
let name = document.querySelector('#nome');
let email = document.querySelector('#email');
let username = document.querySelector('#usuario');
let password = document.querySelector('#senha');
const btnUpdate = document.querySelector('#update');

/*Obtem o Id do usuário a ser atualizado*/
const id = localStorage.getItem('userId');

/*Chama a funcão GetUser ao carregar a pagina*/
document.addEventListener('DOMContentLoaded', GetUser);

/*Observa o evento de click para executar a função Update*/
btnUpdate.addEventListener('click', Update);

/*Carrega na tela o usuário correspondente ao id*/
function GetUser() {
    api.getUser(id)
        .then(res => {
            console.log(res);            
            name.value = res.name;
            email.value = res.email;
            username.value = res.username;
            password.value = res.password;
        })
        .catch(err => {
            console.log(err);
        })
}

function clear() {
    name.value = '';
    email.value = '';
    username.value = '';
    password.value = '';
}
/*Executa o método de update da api*/
function Update() {
    const user = {
        id: id,
        name: name.value,
        email: email.value,
        username: username.value,
        password: password.value
    }
    console.log(user);    
    api.putUser(id, user);    
    alert("Cadastro Atualizado");
    clear();
    window.location.href = "userlist.html";
}

