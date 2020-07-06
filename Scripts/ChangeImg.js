function ShowImgPrev(imgUpLoad, prev) {
    if (imgUpLoad.files && imgUpLoad.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(prev).attr('src', e.target.result);
        }
        reader.readAsDataURL(imgUpLoad.files[0]);
    }
}

