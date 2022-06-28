
/** funcao responsavel para calcular o preco de cada produto */
function CalcXml(porcetagem, identificao) {
    if (Valida(identificao)) {
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
}
/*Responsavel por valida se quantidade de itens na cx foi escrito*/
function Valida(identificao) {
    var validacao = false
    var quantidadeUnitaria = document.getElementById('unitario ' + identificao).value;
    console.log(quantidadeUnitaria);
    if (quantidadeUnitaria != "") {
        validacao = true
        console.log(validacao)
    } else {
        alert("Favor digitar quantidade que veio dentro da CX");
    }
}