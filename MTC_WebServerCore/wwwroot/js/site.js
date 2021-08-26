// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}

function confirmReplenishStock() {
    var arrayOfOrders = [];
    // gets all the rows in the table 
    var orders = $("#orderTable tbody tr");
  
    //loops over each row  and fires the function
    orders.each(function () {
        //Gets all the descendants of row which are checked
        var selectedCheckBox = $(this).find("input.checkBox");
        console.log("Selected = " + selectedCheckBox.length);
        console.log("Selected = " + selectedCheckBox[0].checked);
       
        
        //if checked descendant found (length not 0) selected save the values into a new object(EAN, name, amount and supplier)
        if (selectedCheckBox[0].checked) {

            var EAN = $(this).attr("id");
            var name = $(this).children()[2].innerText;
            var RecommendedUnitPrice = $(this).children()[3].innerText;
            var CountInStock = $(this).children()[4].innerText;
            var MinStock = $(this).children()[5].innerText;
            var MaxStock = $(this).children()[6].innerText;

            var amountToOrder = $(this).find(".amountToOrder").eq(0).val();
            var supplier = $(this).find("option:selected").val();
            //properties of object should match with vm property names
            var order = {
                product: {
                    EAN: EAN,
                    name: name,
                    RecommendedUnitPrice: RecommendedUnitPrice,
                    CountInStock: CountInStock,
                    MinStock: MinStock,
                    MaxStock: MaxStock
                },
                amountToOrder: amountToOrder,
                supplierID: supplier
            }

            arrayOfOrders.push(order);
        }
    });

    console.log(arrayOfOrders);
    //post request to action containing array of orders
    $.post('/OrderIn/ReplenishStock',
        { orders: arrayOfOrders },
        function (data, status) {
            window.location = "/OrderIn/OverviewOrders";
        }
    )

}