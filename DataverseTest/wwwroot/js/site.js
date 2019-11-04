
//Turn contact table into datatable
$(document).ready(function () {
    $('#contactTable').DataTable();
});

//Turn phones table into Datatable
$(document).ready(function () {
    $('#phonesTable').DataTable();
});

//Popup to ask user before contact delete

$("form#deleteContact").submit(function (event) {
    event.preventDefault();
        Swal.fire({
        title: 'Are you sure you want to delete Contact?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
        if (result.value == true) {
            this.submit();
        }
        })
}); 

$("form#deletePhone").submit(function (event) {
    event.preventDefault();
    Swal.fire({
        title: 'Are you sure you want to delete Phone?',
        text: "You won't be able to revert this!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value == true) {
            this.submit();
        }
    })
}); 
