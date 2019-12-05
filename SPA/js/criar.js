const api = new Api();

document.querySelector('#cadastrar').addEventListener('click', CreateUser);

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
    //console.log(user);
    api.postUser(user); 
    alert("Registrado com sucesso!");    
}
