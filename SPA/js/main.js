const api = new Api();
const btn = document.querySelector('#btn');
const tbody = document.querySelector('#tb');

document.addEventListener('DOMContentLoaded', GetUsers);

function storage(id) {
    localStorage.setItem('userId', id);
}

function GetUsers() {
    api.getUSers()
        .then(res => {
            const data = res;
            let output = '';
            data.forEach(el => {
                output +=
                    `
                <tr class="">                
                    <td>${el.name}</td>
                    <td>${el.email}</td>                   
                    <td>${el.username}</td>                   
                    <td class="d-flex justify-content-end">
                        <a href="#" class="btn-sm btn btn-danger m-1" onclick="api.deleteUser(${el.id})"><i class="fas fa-trash-alt"></i></a>
                        <a href="getbyid.html" class="edit btn-sm btn-info m-1" onclick="storage(${el.id})"><i class="fas fa-info-circle"></i></a>
                        <a href="editar.html" class="btn-sm btn-success m-1" onclick="storage(${el.id})"><i class="fas fa-edit"></i></a>
                    </td>                   
                </tr>
             `
            })
            tbody.innerHTML = output;
        })
        .catch(err => console.log(err))
}

function Edit() {
   const place =  document.querySelector('.place');
   place.style.display = 'block'
}




