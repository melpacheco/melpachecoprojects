$(document).ready(function () {   

    refreshAtZero();

    loadInventory();

    $("#addDollar").click(function (event){
        var addedAmount = ((GetValueInTotalInBox()) + 1.00);
      $("#totalInBox").val(addedAmount.toFixed(2));
    });

    $("#addQuarter").click(function (event){
    var addedAmount = ((GetValueInTotalInBox()) + .25);
    $("#totalInBox").val(addedAmount.toFixed(2));
    });

    $("#addDime").click(function (event){
    var addedAmount = ((GetValueInTotalInBox()) + .10);
    $("#totalInBox").val(addedAmount.toFixed(2));
    });

    $("#addNickel").click(function (event){
    var addedAmount = ((GetValueInTotalInBox()) + .05);
    $("#totalInBox").val(addedAmount.toFixed(2));
    });

    $("#makePurchase").click(function (event){
        var amount = GetValueInTotalInBox();
        var id = Number($("#itemSelection").val());
        vendItem(amount, id);
        $("#totalInBox").val("");
        loadInventory();
    });

})

function loadInventory(){
    clearCardDeck();
    var cards = $(".card-deck");
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/items",
        success: function (data, status){
            $.each(data, function(index, item){

                var column = document.createElement("column");
                column.className = "column";

                var card = document.createElement("div")
                card.className = "card";
                card.id = "card" + item.id;
                
                var cardHeader = document.createElement("div");
                cardHeader.textContent = item.id;
                cardHeader.className = "card-header";

                var cardTitle = document.createElement("h5");
                cardTitle.textContent = item.name;
                cardTitle.className = "card-title";

                var cardBody = document.createElement("div");
                cardBody.textContent = "$" + item.price.toFixed(2);
                cardBody.className = "card-body";

               var cardFooter = document.createElement("div");
               cardFooter.textContent = "Quantity Left:" + item.quantity;
               cardFooter.className = "card-footer";


                cards.append(column);
                column.append(card);
                card.append(cardHeader);
                card.append(cardTitle);
                card.append(cardBody);
                card.append(cardFooter)

                $("#card" + item.id).click(function(event){
                    $("#itemSelection").val(Number(item.id));
                })
        
        });
    },
        error: function(){
            alert("FAIL");
        }
       
    });

    $("#changeReturn").click(function (event){
        var amount = Number($("#totalInBox").val()).toFixed(2);
        var cents = Number(Math.round(amount*100));
        $("#totalInBox").val(" ");
        $("#itemSelection").val(" ");
         $("#changeReturned").val(returnCoinAmounts(cents));
    });

    
}

function clearCardDeck(){
    $(".card-deck").empty();
}

function GetValueInTotalInBox(){
var amount = $("#totalInBox").val();

if (amount == ""){
    return amount = 0;
}
 
return Number(amount);
}

function refreshAtZero(){
    $("#totalInBox").val("");
    $("#itemSelection").val("");
    $("#changeReturned").val("");
    $("#messages").val("");
}

function vendItem(amount, id){
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/money/" + amount + "/item/" + id,
        contentType: "applicaton/json",
        accept: "application/json",
        success: function(index, item){
            $("#messages").val("Thank You!!!")
            var quarters = index.quarters;
            var dimes = index.dimes;
            var nickels = index.nickels;

            changeReturned(quarters, dimes, nickels);
        },
        error: function(data){
         $("#messages").val((data.responseJSON.message));
        }
    });
    
}

function changeReturned(quarters, dimes, nickels){
    var quartersNumber = returnQuarters(quarters)
    var dimesNumber = returnDimes(dimes)
    var nickelNumber = returnNickels(nickels);

    $("#changeReturned").val(quartersNumber +" "+ dimesNumber +" "+ nickelNumber);
}


function returnQuarters(quarters){
    if (quarters != "0"){
        var quarterNumber = Number(quarters);
        return (quarterNumber + " Quarters")
    };
    
    return "";
}

function returnDimes(dimes){
    if(dimes != "0"){
        var dimeNumber = Number(dimes);
        return (dimeNumber + " Dimes");
    };
    return "";
}

function returnNickels(nickels){
    if (nickels != "0"){
        var nickelNumber = Number(nickels);
        return (nickelNumber + " Nickels")
    };

    return "";
}

function amountToCoins(amount, coins){
    if (amount == 0)
    {
        return [];
    }
    else
    {
        if(amount >= coins[0])
        {
        left = (amount - coins[0]);
        return [coins[0]].concat( amountToCoins(left, coins ));
        }
        else
        {
        coins.shift();
        return amountToCoins(amount, coins);
        }
    }
}

function returnCoinAmounts(amount){

    var quarterCount = 0;
    var dimeCount = 0;
    var nickelCount = 0;

 amountToCoins(amount, [25, 10, 5]).forEach(element => {
        if (element == 25){
            quarterCount++;
        }
        if (element == 10){
            dimeCount++;
        }
        if (element == 5){
            nickelCount++
        }
    });

   var quartersNumber =  returnQuarters(quarterCount);
   var dimesNumber = returnDimes(dimeCount);
   var nickelNumber = returnNickels(nickelCount);

   var message = (quartersNumber + " " + dimesNumber + " " + nickelNumber);

    return message;
}



