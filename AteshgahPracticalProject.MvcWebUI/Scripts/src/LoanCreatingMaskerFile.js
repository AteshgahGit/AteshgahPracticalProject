
//---------------------------------Phone number masker
var element = document.getElementById('phoneNumberCreateLoanInput');
var maskOptions = {
    mask: '+{994}(00)000-00-00'
};
var mask = IMask(element, maskOptions);

//---------------------------------Only Number Masker
var justNumberElementLoanAmount = document.getElementById('loanAmountCreateLoanInput');
var numberMask = IMask(
    justNumberElementLoanAmount,
    {
        mask: Number,
        min: 100,
        max: 5000,
        thousandsSeparator: ' '
    });

justNumberElementLoanAmount.addEventListener('keyup', function () {
    if (justNumberElementLoanAmount.value.substring(justNumberElementLoanAmount.value.length - 1, justNumberElementLoanAmount.value.length) == ',' ||
        justNumberElementLoanAmount.value.substring(justNumberElementLoanAmount.value.length - 1, justNumberElementLoanAmount.value.length) == '.') {
        if (justNumberElementLoanAmount.value.length == 1) {
            justNumberElementLoanAmount.value = '';
        }
        justNumberElementLoanAmount.value = justNumberElementLoanAmount.value.substring(0, justNumberElementLoanAmount.value.length - 1);
    }
});


//-----------------------------Date Masker
var dateInputElement = document.querySelector('#payoutDateTimeCreateLoanInput');

var dateInputMask = function dateInputMask(elm) {
    elm.addEventListener('keypress', function (e) {
        if (e.keyCode < 47 || e.keyCode > 57) {
            e.preventDefault();
        }

        var len = elm.value.length;

        // If we're at a particular place, let the user type the slash
        // i.e., 12/12/1212
        if (len !== 1 || len !== 3) {
            if (e.keyCode == 47) {
                e.preventDefault();
            }
        }

        // If they don't add the slash, do it for them...
        if (len === 2) {
            elm.value += '/';
        }

        // If they don't add the slash, do it for them...
        if (len === 5) {
            elm.value += '/';
        }
    });
};

dateInputMask(dateInputElement);

dateInputElement.addEventListener('blur', function (e) {
    if (dateInputElement.value.length != 10) {
        dateInputElement.value = '';
    }
});

//---------------------------------Interest Rate Masker
var inputInterestRate = document.getElementById('monthlyInterestCreateLoanInput');

var numberMask = IMask(inputInterestRate,
    {
        mask: Number,
        min: 0,
        max: 100
    });

inputInterestRate.addEventListener('blur', function () {
    if (inputInterestRate.value.length != 0 && inputInterestRate.value[inputInterestRate.value.length] != '%') {
        inputInterestRate.value += ' %';
    }
});

inputInterestRate.addEventListener('focus', function () {
    if (inputInterestRate.value.substring(inputInterestRate.value.length - 1, inputInterestRate.value.length) == '%') {
        inputInterestRate.value = inputInterestRate.value.substring(0, inputInterestRate.value.length - 2);
    }
});