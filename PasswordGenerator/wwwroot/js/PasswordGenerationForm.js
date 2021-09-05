$(document).ready(() => {
    $(".focus-input").focus();

    if (window._password_generation_form_script_loaded === undefined) {
        window._password_generation_form_script_loaded = true;

        $("body").on("click", ".btn-generate-password", e => {
            e.preventDefault();
            submitGeneratePasswordForm($(e.target));
            return false;
        });

        $("body").on("change", ".rb-person-type", e => {
            changedPersonType($(e.target).closest("form"));
        });
    }
});

function submitGeneratePasswordForm($clickedBtn) {
    const $form = $clickedBtn.closest("form");
    const $container = $clickedBtn.closest(".div-password-generation-form");

    $.ajax({
        data: $form.serialize(),
        type: $form.prop('method'),
        url: $form.prop('action'),
        success: response => {
            $container.replaceWith(response);
        },
        error: () => {
            alert("Something went wrong!");
        }
    });
}

function changedPersonType($form) {
    const $selectedRb = $form.find('.rb-person-type:checked');

    if ($selectedRb.data("person-type") == "teacher") {
        $form.find(".student-info").addClass("d-none");
    } else if ($selectedRb.data("person-type") == "student") {
        $form.find(".student-info").removeClass("d-none");
    }
}