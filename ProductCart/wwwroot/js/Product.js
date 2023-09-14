
function addNewProduct() {
    // Redirect to the Add_NewProduct page
    window.location.href = '/ProductUI/Add_NewProduct';
}


//START Product View Popup

$(document).ready(function () {
    $(".product-box").on("click", function () {
        var productId = $(this).data("product-id");

        // AJAX call to fetch product details using the product ID
        $.ajax({
            url: "/ProductUI/ProductDetailsById/" + productId,
            type: "GET",
            success: function (data) {
               // console.log(data);
                // Update the modal body with the product details
                $("#productDetailsContent").html(data);


                showPopup();
            },
            error: function () {
                alert("Error fetching product details. Please try again.");
            }
        });
    });

    // Close the popup when close button is clicked
    $("#closePopup").on("click", function () {
        hidePopup();
    });

    // Close the popup when clicking outside the content area
    $(document).on("click", function (event) {
        if ($(event.target).is("#popupOverlay")) {
            hidePopup();
        }
    });
});

function showPopup() {
    $("#popupOverlay").fadeIn();
}

function hidePopup() {
    $("#popupOverlay").fadeOut();
}

//END Product View Popup

//Start Add To cart
$("#cartLogo").click(function () {
    
    var cartUrl = "/ProductUI/Cart";
    window.location.href = cartUrl;
});

function updateCartCount(cartCount) {
    let cartCountElement = document.getElementById("cartCount");
    cartCountElement.textContent = cartCount;

    localStorage.setItem("cartCount", cartCount);
}

function fetchCartCount() {
    $.ajax({
        url: "/ProductUI/GetCartCount",
        type: "GET",
        success: function (response) {
            updateCartCount(response.cartCount);
        },
        error: function (error) {
            console.error("Error fetching cart count: ", error);
        }
    });
}

function addToCart(productId) {
    debugger;
    $.ajax({
        url: "/ProductUI/Cart",
        type: "POST",
        data: { productId: productId },
        success: function (response) {
            // Fetch the updated cart count from the server
            fetchCartCount();
        },
        error: function (error) {
            console.error("Error adding product to cart: ", error);
        }
    });
}

// Fetch the cart count from the server when the page loads
document.addEventListener("DOMContentLoaded", function () {
    let cartCount = localStorage.getItem("cartCount");
    if (cartCount !== null) {
        updateCartCount(cartCount);
      
    } else {
        // Fetch the cart count from the server if not available in Local Storage
        fetchCartCount();
    }
});



//End Add To cart