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
        var selectedCheckBox = $(this).find(":checked");
        
        //if checked descendant found (length not 0) selected save the values into a new object(EAN, name, amount and supplier)
        if (selectedCheckBox.length > 0) {
            var EAN = $(this).attr("id");
            var name = $(this).children()[2].innerText;
         
            var amountToOrder = $(this).find(".amountToOrder").eq(0).val();
            var supplier = $(this).find("option:selected").val();
            //properties of object should match with vm property names
            var order = {
                product: {
                    EAN: EAN,
                    name: name,
                },
                amountToOrder: amountToOrder,
                supplierID: supplier
            }

            arrayOfOrders.push(order);
        }
    });

    //console.log(arrayOfOrders);
    //post request to action containing array of orders
    $.post('/OrderIn/ReplenishStock',
        { orders: arrayOfOrders },
        function (data, status) {
            console.log('status:' + status + 'data:' + data)
        }
    )

}