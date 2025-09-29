function updateShoppingCartItems(count) {
    if (count <= 0) {
        $("#shoppingItemsCount").html("0");
        $("#shoppingItemsCount").hide();
    }
    else {
        $("#shoppingItemsCount").html(count);
        $("#shoppingItemsCount").show();
    }
}