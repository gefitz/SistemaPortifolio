
/** funcao responsavel para calcular o preco de cada produto */
function CalcXml(porcetagem, identificao) {
    quantidadeCX = parseInt(document.getElementById('quant ' + identificao).innerText);
    quantidadeUnitaria = document.getElementById('unitario ' + identificao).value;
    quantidadeUnitaria = parseFloat(quantidadeUnitaria.replace(",", "."))
    valorUnitario = parseFloat(document.getElementById('valorUnitario ' + identificao).innerText);
    valorTotal = parseFloat(document.getElementById('valorTotal ' + identificao).innerText);
    tipoItem = document.getElementById('tipoItem ' + identificao).innerText;
    if (tipoItem === "KG") {

        porcetagem = porcetagem / 100;
        valorUnitario = valorUnitario * quantidadeUnitaria;
        result = valorUnitario + (porcetagem * valorUnitario);

    }
    else if (valorUnitario == valorTotal) {


        porcetagem = porcetagem / 100;
        valorUnitarioDaCaixa = valorTotal / quantidadeCX;
        valorUnitario = valorUnitarioDaCaixa / quantidadeUnitaria;
        result = valorUnitario + (porcetagem * valorUnitario);
    }
    else {
        valorUnitario = parseFloat(valorUnitario);
        porcetagem = porcetagem / 100;
        var n1 = valorUnitario * porcetagem;
        result = valorUnitario + n1;

    }
    console.log(result);
    document.getElementById('final ' + identificao).innerHTML = result;
}

/**  */


function SalvarProdutos() {
    /*fazer um json e enviar um por cada dentro do for para controller,controller devera retornar succes*/ 
    var tabela = document.getElementById("tabela");
    var linha = tabela.getElementsByTagName("tr");
    for (i = 0; i < linha.length; i++) {
        var codigo = document.getElementById('codigo '+ i).value
        var nome = document.getElementById('nome ' + i).innerText
        var quantidadeCaixas = document.getElementById('quant ' + i).innerText
        var quantidadeUnitario = document.getElementById('unitario ' + i).value
        var valorUnitario = document.getElementById('valorUnitario ' + i).innerText
        var valorTotalCx = document.getElementById('valorTotal ' + i).innerText
        var porcetagem = document.getElementById('inputGroupSelect ' + i)
            porcetagem = porcetagem.options[porcetagem.selectedIndex].text
        var valorFinal = document.getElementById('final ' + i).innerText
        var json = {
            "Codigo": codigo,
            "Nome": nome,
            "QuantidadeCX": quantidadeCaixas,
            "QuantidadeUN": quantidadeUnitario,
            "ValorUnitario":  valorUnitario,
            "ValorTotalCx": valorTotalCx,
            "PrecoFinal": valorFinal,
            "Porcetagem": porcetagem,
        }
        console.log(json)
        $.ajax({
            url: "SalvarProduto",
            method: "POST",
            data: json,
        })
        
    }
}