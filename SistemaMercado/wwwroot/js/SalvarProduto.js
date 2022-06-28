/*Function responsavel de enviar produto para controller para ser salva*/
function SalvarProdutos() {
    var tabela = document.getElementById("tabela");
    var produtos = tabela.getElementsByTagName("tr");
    if(Validacao()) {

        for (i = 1; i < produtos.length; i++) {
            var codigo = document.getElementById('codigo ' + i).value;
            var nome = document.getElementById('nome ' + i).innerText;
            var quantidadeCaixas = document.getElementById('quant ' + i).innerText;
            var quantidadeUnitario = document.getElementById('unitario ' + i).value;
            var valorUnitario = document.getElementById('valorUnitario ' + i).innerText;
            var valorTotalCx = document.getElementById('valorTotal ' + i).innerText;
            var porcetagem = document.getElementById('inputGroupSelect ' + i);
            porcetagem = porcetagem.options[porcetagem.selectedIndex].text;
            var valorFinal = document.getElementById('final ' + i).innerText;

            var json = {
                "Codigo": codigo,
                "Nome": nome,
                "QuantidadeCX": quantidadeCaixas,
                "QuantidadeUN": quantidadeUnitario,
                "ValorUnitario": valorUnitario,
                "ValorTotalCx": valorTotalCx,
                "PrecoFinal": valorFinal,
                "Porcetagem": porcetagem,
            }
            $.ajax({
                url: "SalvarProduto",
                method: "POST",
                data: json,
            })

        }
   }
}
function Validacao() {
    var produtos = document.querySelectorAll('#tabela tr');
    console.log(produtos)
    let listErro = [];
    
    var validacao = true;
    for (i = 0; i < produtos.length-1; i++) {
        
        var j = 0;
        var codigo = document.getElementById('codigo ' + i).value;
        var quantidadeUnitario = document.getElementById('unitario ' + i).value;
        var valorFinal = document.getElementById('final ' + i).innerText;

        if (codigo === "" && quantidadeUnitario === "" && valorFinal === "") {
            listErro[j] = i;
            j++;
        }
    }
    if (listErro[0] != null) {
                  validacao = false;
            alert("Faltando algumas informações em alguns Produtos ");
        
        return validacao;
    }

}