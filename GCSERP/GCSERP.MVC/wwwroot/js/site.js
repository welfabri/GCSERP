// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function apagarProduto(id) {
    bootbox.confirm("Deseja apagar o item selecionado?",
        function (result) {
            if (result) {
                apagarProdutoInterno(id);
            }                
        }
    );
}

function apagarProdutoInterno(id) {
    fetch(`/produto/apagar/${id}`, {
        method: 'DELETE'
    })
        .then(() => bootbox.alert('ok!'))
        .catch(error => bootbox.alert('Não foi possível apagar o item:', error));
}