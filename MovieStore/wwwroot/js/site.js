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

//let copyCount = 0;

//// Step 2: Increment the copy count when a movie is added to the checkout
//function addToCheckout() {
//    copyCount++;
//}

//// Step 3: Display the copy count in the checkout interface
//function displayCopyCount() {
//    console.log(`Number of copies in checkout: ${copyCount}`);
//}