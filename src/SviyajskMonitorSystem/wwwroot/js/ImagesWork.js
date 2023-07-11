
$("#Photo").change(function () {
    
    // выводим объект FileList
    
    for (var i = 0, f; f = this.files[i]; i++) {
        if (!f.type.match('image.*')) {
            continue;
        }
        var reader = new FileReader();
        reader.onload = (function (theFile) {
            return function (e) {
                // Render thumbnail.
                var image = document.createElement('img');
                image.setAttribute("src", e.target.result);
                $('#images').append(image);
            };
        })(f);

        // Read in the image file as a data URL.
        reader.readAsDataURL(f);
    }
    
    });



//function OnImageAdded() {
//   // alert("in");
//    console.log( this.files);
//    for (var i = 0, f; f = this.files[i];  i++) {
//        if (!f.type.match('image.*')) {
//            continue;
//        }
//        var reader = new FileReader();
//        reader.onload = (function (theFile) {
//            return function (e) {
//                // Render thumbnail.
//                var image = document.createElement('img');
//                image.setAttribute("src", e.target.result);
//                document.getElementById('images').insertBefore(image, null);
//            };
//        })(f);

//        // Read in the image file as a data URL.
//        reader.readAsDataURL(f);
//    }
//}

