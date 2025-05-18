const form = document.getElementById('formCadastro');
const nome = document.getElementById('nome');
const preco = document.getElementById('preco');
const descricao = document.getElementById('descricao');
const imagem = document.getElementById('imagem');

function onSave(event) {
    event.preventDefault();
    if (!nome.value || !preco.value || !descricao.value || !imagem.files[0]) {
        alert("Todos os campos devem ser preenchidos.");
        return;
    }

    const precoDecimal = parseFloat(preco.value);

    if (isNaN(precoDecimal)) {
        alert("Por favor, insira um preço válido.");
        return;
    }

    const formData = new FormData();
    formData.append('nome', nome.value);
    formData.append('preco', precoDecimal);
    formData.append('descricao', descricao.value);
    formData.append('imagem', imagem.files[0]);

    fetch('https://localhost:7247/api/Produto', {
        method: 'POST',
        body: formData, 
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Erro ao cadastrar o produto');
            }
            return response.json(); 
        })
        .then(data => {
            alert('Produto cadastrado com sucesso!');
            console.log(data);
        })
        .catch(error => {
            alert('Erro ao cadastrar produto: ' + error.message);
        });
}
form.addEventListener('submit', onSave);
