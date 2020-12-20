
let toggleShowInvoiceListCreating = $('.tableLoanListCreatingTime');
let allCustomCreationInputs = $('.customHandlingForInputEnabled');
let btnCancelInvoiceUpdating = $('#btnCancelInvoicesAccepting');
let btnCancelModalInvoiceCreating = $('#btnCancelModalInvoiceCreating');
let btnCreateInvoice = $('#btnCalculateInvoiceCreating');
let btnCancelCreatingMainFirst = $('#btnCancelCreatingMainFirst');
let tableRow = $(".clickedRow");


function ClearContents() {
    for (let k = 0; k < $('#clientListCreateLoanInput').children().length; k++) {
        $('#clientListCreateLoanInput').children()[k].removeAttribute('selected');
    }
    $('#clientListCreateLoanInput').children()[0].setAttribute('selected', '');

    for (let z = 0; z < $('#monthPeriodCreateLoanInput').children().length; z++) {
        $('#monthPeriodCreateLoanInput').children()[z].removeAttribute('selected');
    }
    $('#monthPeriodCreateLoanInput').children()[0].setAttribute('selected', '');

    $("#phoneNumberCreateLoanInput").val('');
    $("#payoutDateTimeCreateLoanInput").val('');
    $("#monthlyInterestCreateLoanInput").val('');
    $("#loanAmountCreateLoanInput").val('');
}
btnCreateInvoice.click(function (e) {

    let clientID = $("#clientListCreateLoanInput").find(":selected").data("clientid");
    let loanMaount = $("#loanAmountCreateLoanInput").val();
    let interestRate = $("#monthlyInterestCreateLoanInput").val();
    let period = $("#monthPeriodCreateLoanInput").find(":selected").val();
    let payoutDate = $("#payoutDateTimeCreateLoanInput").val();
    let phone = $("#phoneNumberCreateLoanInput").val();

    let dataModel = {
        ClientID: clientID,
        LoanAmount: loanMaount,
        InterestRate: interestRate,
        LoanPeriod: period,
        PayoutDate: payoutDate,
        TelephoneNr: phone
    }

    if (dataModel.ClientID < 1 ||
        parseInt(dataModel.LoanAmount) < 100 ||
        parseInt(dataModel.LoanAmount) > 5000 ||
        dataModel.TelephoneNr.length < 7 ||
        payoutDate.length<10) {

        alert("Js Validation: Fill in The Inputs");
        return;
    }

    $.ajax({
        url: "/Invoice/GetCalculatedInvoiceDetails",
        method: "POST",
        data: { calculateModel: dataModel },
    }).done(function (d) {
        $("#tableLoanListCreatingTime").html("");
        $("#tableLoanListCreatingTime").html(d);
        $("#tableLoanListCreatingTime").removeAttr("class");
        $("#tableLoanListCreatingTime").attr("class", "tableLoanListCreatingTime");
    }).fail(function () {
        alert("Something Gets Wrong!")
    });
});

btnCancelCreatingMainFirst.click(function () {
    ClearContents();
    $("#tableLoanListCreatingTime").addClass("d-none");
})

btnCancelModalInvoiceCreating.click(function () {
    ClearContents();
    $("#tableLoanListCreatingTime").addClass("d-none");
})

tableRow.click(function (e) {
    let row = $(e.target.parentElement);
    let id = row.data('id');

    $.ajax({
        url: "/Invoice/GetInvoiceDetails/" + id,
        method: "GET"
    }).done(function (d) {
        $("#detailInvoicesOnly").html(d);
    }).fail(function () {
        alert("Something Get Wrong");
    });
});

function updateLoanList() {

    $.ajax({
        url: "/Loan/UpdateLoans",
        method: "POST"
    }).done(function (d) {
        $("#loanListTableBodyTag").empty();
        $("#loanListTableBodyTag").html(d);
    }).fail(function () {
        alert("Loans Did not Uploaded");
    });
}