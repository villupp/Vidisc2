"use strict;"

var courses = (function () {
    return {
        debugEnabled: true,
        maxHoleCount: 1,
        currentHoleCount: 1,

        showHoleFields: showHoleFields,
        createAndAssignCoursesString: createAndAssignCoursesString,
        initializeCreateCourse: initializeCreateCourse
    };

    /* Shows and hides hole input fields according to holeCount field value */
    function showHoleFields(holeCount) {
        writeDebug("showHoleFields holeCount: " + holeCount);

        holeCount = parseInt(holeCount);
        courses.currentHoleCount = holeCount;

        /* Show hole count # of fields */
        for (var i = 1; i <= holeCount; i++) {
            $('#' + i + '.hole-row').show();
            $('#hole-par-' + i).prop('required', true);
            $('#hole-length-' + i).prop('required', true);
        }

        /* Hide others */
        for (var i = holeCount + 1; i <= courses.maxHoleCount; i++) {
            $('#hole-par-' + i).val('');
            $('#hole-length-' + i).val('');
            $('#hole-par-' + i).prop('required', false);
            $('#hole-length-' + i).prop('required', false);
            $('#' + i + '.hole-row').hide();
        }
    }

    /* Creates the hole string and assigns it to hidden field on form */
    function createAndAssignCoursesString() {
        writeDebug("createAndAssignCoursesString");

        var coursesStr = "";

        for (var i = 1; i <= courses.currentHoleCount; i++) {
            var par = $('#hole-par-' + i).val();
            var length = $('#hole-length-' + i).val();

            coursesStr += par + ";" + length + "|";
        }

        writeDebug("coursesStr:");
        writeDebug(coursesStr);
        $('#course-holes-str').val(coursesStr);
    }

    /* Initialize new course form (on document.ready) */
    function initializeCreateCourse() {
        writeDebug("initializeCreateCourse");

        /* Set maxholecount by element count */
        courses.maxHoleCount = $(".hole-row").length;

        writeDebug("courses.maxHoleCount: " + courses.maxHoleCount);

        /* Update hole field count on change of select field */
        $('#hole-count').on('change', function (e) {
            var optionSelected = $("option:selected", this);
            var valueSelected = this.value;
            courses.showHoleFields(valueSelected);
        });

        /* Show 1 hole field initially */
        courses.showHoleFields(courses.currentHoleCount);
    }
   
    /* Writes a message to console.log if debugging is enabled for module */
    function writeDebug(message) {
        if (courses.debugEnabled) {
            console.log("Courses | " + message);
        }
    }
})();

$(document).ready(function () {
    courses.initializeCreateCourse();
});

