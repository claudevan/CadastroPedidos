$(document).ready(function () {

});

function adicionarItem() {
    if ($("#produto option:selected").val() == "") return false;

    $.ajax({
        type: "POST",
        
        data: { IdProduto: parseInt($("#produto option:selected").val()) },
        url: "/Pedido/GetItem",
        success: function (data, textStatus, xhr) {
            
            $("#tblProdutos > tbody").append(
                "<tr>" +
                    "<td style=\"display:none\">" + data.Produto.Id + "</td>" +
                    "<td>" + data.Produto.Descricao + "</td>" +
                    "<td><input type=\"number\" id=\"txtQuantidade\" onchange=\"calcTotal(this)\"/></td>" +
                    "<td>" + data.Produto.Valor + "</td>" +
                    "<td><label id='lblTotalItem'></td>" +
                    "<td><a href=\"#\" onclick=\"removeItem(this)\"><span class=\"glyphicon glyphicon-trash\" aria-hidden=\"true\"></span></a></td>" +
                "</tr>"
            );
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Erro ao adicionar Item");
        }
    });

}

function removeItem(clickLink) {
    $(clickLink).parent().parent().remove();
}

function Salvar() {
    var pedido = {};

    pedido.Cliente = $("#Cliente option:selected").val();
    pedido.DataEntrega = $("#DataEntrega").val();

    pedido.Itens = [];

    $("#tblProdutos > tbody > tr").each(function () {
        
        var tds = $(this).find("td");

        pedido.Itens.push({
            ProdutoId: parseInt($(tds[0]).text()),
            Quantidade: parseFloat($($(tds[2]).children("input")).val().replace(",", ".")),
            Valor: parseFloat($($(tds[4]).children("label")).val().replace(",", "."))
        });
    });


    $.ajax({
        type: "POST",
        data: { pedido: pedido },
        url: "/Pedido/Salvar",
        success: function (data, textStatus, xhr) {
            alert("Funcionou");
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("Erro Salvar Pedido");
        }
    });
}

function calcTotal(inputQtd) {

    var tr = $(inputQtd).parent().parent();

    var qtd = $(inputQtd).val();
    var valor = $($(tr).find("td")[3]).text();

    $($(tr).children("td").children("label")).val(qtd * valor);
}