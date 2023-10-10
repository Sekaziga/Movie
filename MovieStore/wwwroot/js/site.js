
function Add(movieId) {

    $.ajax({
        type: 'post',
        url: 'Order/AddToCart',
        dataType: 'json',
        data: { id: movieId },
        success: function (count) {
            $('#cartCount').html(count);
            showCart();
        }
    })
}

function showCart() {
    var cartEle = document.getElementById("cartDiv");
    cartEle.classList.remove("notShowCart");
    cartEle.classList.add("showCart");

}


