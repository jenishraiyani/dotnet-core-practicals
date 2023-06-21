// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$(function () {
//    var placeHolder = $('#ViewContent');

//    $('button[data-toggle = "ajax-modal"]').click(function (event) {
//        var url = $(this).data('url');
//        var decodedUrl = decodeURIComponent(url);
//        $.get(decodedUrl).done(function (data){
//            placeHolder.html(data);
//            placeHolder.find('.model').modal('show');
//        })
         
//    })

//    placeHolder.on('click', '[data-save="modal"]',
//        function (event) {
//            var form = $(this).parents('.modal').find('form');
//            var actionUrl = form.attr('action');
//            var url = "/Student/" + actionUrl;
//            var sendData = form.serialize();
//            $.post(url, sendData).done(function (data){
//                placeHolder.find('.modal').modal('hide');
//            })
//        }
//    )
//})