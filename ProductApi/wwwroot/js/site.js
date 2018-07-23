const uri = 'api/product';
let products = null;

//counts all elements in database
function getCount(data) {
    const el = $('#counter');
    let name = 'product';
    if (data) {
        if (data > 1) {
            name = 'products';
        }
        el.text(data + ' ' + name);
    } else {
        el.html('No ' + name);
    }
}

$(document).ready(function () {
    getData();
});

//gets a list of to do items sending an HTTP GET request to /api/product
function getData(txt) {
    $.ajax({
        type: 'GET', //request type
        url: uri, // request url
        success: function (data) { //callback function when request succeeds
            $('#products').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                $('<tr><td>' + item.id + '</td>' +
                    '<td>' + '<a onclick="getSpecificData(\'' + item.description + '\')">' + item.description + '</a></td>' +
                    '<td>' + '<a onclick="getSpecificData(\'' + item.model + '\')">' + item.model + '</a></td>' + '</td>' +
                    '<td>' + '<a onclick="getSpecificData(\'' + item.brand + '\')">' + item.brand + '</a></td>' + '</td>' +
                    '<td><button onclick="editItem(\'' + item.id + '\')">Edit</button></td>' +
                    '<td><button onclick="deleteItem(\'' + item.id + '\');">Delete</button></td>' +
                    '</tr>').appendTo($('#products'));
            });
            //DOM is updated with product information
            products = data;
        }
    });
}

//adds a product sending a HTTP POST request to /api/product
function addItem() {
    //contains a product
    const item = {
        'description': $('#add-description').val(),
        'model': $('#add-model').val(),
        'brand': $('#add-brand').val()
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) { //when successful refresh HTML table and remove inputs
            getData();
            $('#add-description').val('');
            $('#add-model').val('');
            $('#add-brand').val('');
        }
    });
}

//deleting a product by id sending a HTTP DELETE request to /api/product
function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getData();
        }
    });
}

//shows input fields if id is correct
function editItem(id) {
    $.each(products, function (key, item) {
        if (item.id === id) {
            $('#edit-id').val(item.id);
            $('#edit-description').val(item.description);
            $('#edit-model').val(item.model);
            $('#edit-brand').val(item.brand);
        }
    });
    $('#spoiler').css({ 'display': 'block' });
}

//updating a product by id sending a HTTP PUT request to /api/product
$('.my-form').on('submit', function () {
    const item = {
        'id': $('#edit-id').val(),
        'description': $('#edit-description').val(),
        'model': $('#edit-model').val(),
        'brand': $('#edit-brand').val()
    };

    $.ajax({
        url: uri + '/' + $('#edit-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

//closes edit input
function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}

function getSpecificData(txt) {
    $.ajax({
        type: 'GET', //request type
        url: uri, // request url
        success: function (data) { //callback function when request succeeds
            $('#products').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                if (item.description === txt || item.model === txt || item.brand === txt) {
                    $('<tr><td>' + item.id + '</td>' +
                        '<td>' + '<a onclick="getSpecificData(\'' + item.description + '\')">' + item.description + '</a></td>' +
                        '<td>' + '<a onclick="getSpecificData(\'' + item.model + '\')">' + item.model + '</a></td>' + '</td>' +
                        '<td>' + '<a onclick="getSpecificData(\'' + item.brand + '\')">' + item.brand + '</a></td>' + '</td>' +
                        '<td><button onclick="editItem(\'' + item.id + '\')">Edit</button></td>' +
                        '<td><button onclick="deleteItem(\'' + item.id + '\');">Delete</button></td>' +
                        '</tr>').appendTo($('#products'));
                }             
            });
            //DOM is updated with product information
            products = data;
        }
    });
}