(function () {
    "use strict";

    let forms = document.querySelectorAll('.php-email-form');

    forms.forEach(function (form) {

        form.addEventListener('submit', function (event) {

            event.preventDefault();

            let thisForm = this;

            let action = thisForm.getAttribute('action');
            if (!action) {
                displayError(thisForm, "Form action property is missing!");
                return;
            }

            thisForm.querySelector('.loading').classList.add('d-block');
            thisForm.querySelector('.error-message').classList.remove('d-block');
            thisForm.querySelector('.sent-message').classList.remove('d-block');

            let formData = new FormData(thisForm);

            fetch(action, {
                method: "POST",
                body: formData
            })
                .then(response => response.text())
                .then(data => {

                    thisForm.querySelector('.loading').classList.remove('d-block');

                    if (data.trim() === "OK") {
                        thisForm.querySelector('.sent-message').classList.add('d-block');
                        thisForm.reset();
                    } else {
                        displayError(thisForm, data);
                    }

                })
                .catch(error => {
                    displayError(thisForm, error);
                });

        });
    });

    function displayError(form, error) {
        form.querySelector('.loading').classList.remove('d-block');
        form.querySelector('.error-message').innerHTML = error;
        form.querySelector('.error-message').classList.add('d-block');
    }

})();
