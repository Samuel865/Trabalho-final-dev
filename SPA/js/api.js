class Api {
    async getUSers() {
        const response = await fetch('https://localhost:5001/api/user/list');
        const data = response.json();
        return data;
    }

    async getUser(id) {
        const response = await fetch(`https://localhost:5001/api/user/${id}`);
        const data = response.json();       
        return data;
    }    

    async  postUser(data) {
        const response = await fetch("https://localhost:5001/api/auth/register", {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify(data)
        });
        const responseData = await response.json();
        return responseData;
    }

    async putUser(id, data) {
        const response = await fetch(`https://localhost:5001/api/user/${id}`, {
            method: 'PUT',
            headers: {
                'Content-type':'application/json'
            },
            body: JSON.stringify(data)
        });
        const responseData = await response.json();
        return responseData;
    }

    async deleteUser(id) {
        if(confirm('Tem certeza que deseja excluír?'))
        {
            await fetch (`https://localhost:5001/api/user/${id}`,{
                method:'DELETE',
                headers: {
                    'Content-type':'application/json'
                }
            });
            window.location.reload();
        }
        else{
            return false;
        }
    }
}