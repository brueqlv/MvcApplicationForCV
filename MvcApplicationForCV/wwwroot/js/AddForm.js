document.getElementById("addAddress").addEventListener("click", function () {
    let container = document.getElementById("addressList");
    let index = container.getElementsByClassName("address-entry").length;
    let newDiv = document.createElement("div");
    newDiv.className = "address-entry";

    newDiv.innerHTML =
        '<div class="form-group">' +
        '<label>Country</label>' +
    '<input type="text" class="form-control" name="PersonalInfo.AddressList[' + index + '].Country" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>City</label>' +
    '<input type="text" class="form-control" name="PersonalInfo.AddressList[' + index + '].City" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Street</label>' +
    '<input type="text" class="form-control" name="PersonalInfo.AddressList[' + index + '].Street" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Street Number</label>' +
    '<input type="text" class="form-control" name="PersonalInfo.AddressList[' + index + '].StreetNumber" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Postal Code</label>' +
    '<input type="text" class="form-control" name="PersonalInfo.AddressList[' + index + '].PostalCode" required/>' +
        '</div>' +
        '<button type="button" class="btn btn-danger btn-sm" onclick="removeEntry(this)">Remove</button>';

    container.appendChild(newDiv);
});

document.getElementById("addEducation").addEventListener("click", function () {
    let container = document.getElementById("education-list");
    let index = container.getElementsByClassName("education-entry").length;
    let newDiv = document.createElement("div");
    newDiv.className = "education-entry";

    let educationStatusOptionsHtml = educationStatusList.map(option =>
        `<option value="${option.Value}">${option.Text}</option>`
    ).join('');

    let educationStatusId = 'educationStatus' + index;
    let endDateId = 'endDate' + index;

    newDiv.innerHTML =
        '<div class="form-group">' +
        '<label>Name</label>' +
    '<input type="text" class="form-control" name="Educations[' + index + '].Name" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Course</label>' +
    '<input type="text" class="form-control" name="Educations[' + index + '].Course" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Education Level</label>' +
    '<input type="text" class="form-control" name="Educations[' + index + '].EducationLevel" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Education Status</label>' +
        '<select class="form-control" id="' + educationStatusId + '" name="Educations[' + index + '].EducationStatuss">' +
        educationStatusOptionsHtml +
        '</select>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Start Date</label>' +
    '<input type="date" class="form-control" name="Educations[' + index + '].StartDate" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>End Date</label>' +
        '<input type="date" class="form-control" id="' + endDateId + '" name="Educations[' + index + '].EndDate"/>' +
        '</div>' +
        '<button type="button" class="btn btn-danger btn-sm" onclick="removeEntry(this)">Remove</button>';

    container.appendChild(newDiv);

    applyToggleLogic(educationStatusId, endDateId);
});

document.getElementById("addWorkExperience").addEventListener("click", function () {
    let container = document.getElementById("work-experiences-list");
    let index = container.getElementsByClassName("work-experience-entry").length;
    let newDiv = document.createElement("div");
    newDiv.className = "work-experience-entry";

    let endDateId = 'workEndDate' + index;
    let stillWorkingId = 'stillWorking' + index;

    newDiv.innerHTML =
        '<div class="form-group">' +
        '<label>Company Name</label>' +
    '<input type="text" class="form-control" name="WorkExperiences[' + index + '].CompanyName" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Position Title</label>' +
    '<input type="text" class="form-control" name="WorkExperiences[' + index + '].PositionTitle" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Position Description</label>' +
    '<input type="text" class="form-control" name="WorkExperiences[' + index + '].PositionDescription" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Weekly Work Load</label>' +
    '<input type="number" class="form-control" name="WorkExperiences[' + index + '].WeeklyWorkLoad" min="0" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>Start Date</label>' +
    '<input type="date" class="form-control" name="WorkExperiences[' + index + '].StartDate" required/>' +
        '</div>' +
        '<div class="form-group">' +
        '<label>End Date</label>' +
        '<input type="date" class="form-control" name="WorkExperiences[' + index + '].EndDate" id="workEndDate' + index + '" />' +
        '</div>' +
        '<div class="form-check">' +
    '<input class="form-check-input" name="WorkExperiences[' + index + '].IsStillWorking" type="checkbox" onchange="toggleEndDateForWork(\'workEndDate' + index + '\', this)" id="stillWorking' + index + '"/>' +
        '<label class="form-check-label" for="stillWorking' + index + '">' +
        'Still Working' +
        '</label>' +
        '</div>' +
        '<button type="button" class="btn btn-danger btn-sm" onclick="removeEntry(this)">Remove</button>';

    container.appendChild(newDiv);
});

document.getElementById("addLanguage").addEventListener("click", function () {
    let container = document.getElementById("language-skill-list");
    let index = container.getElementsByClassName("language-skill-entry").length;
    let newDiv = document.createElement("div");
    newDiv.className = "language-skill-entry";

    let languageSkillOptionsHtml = languageSkillList.map(option =>
        `<option value="${option.Value}">${option.Text}</option>`
    ).join('');

    newDiv.innerHTML = `
                    <div class="form-group">
                        <label>Name</label>
                        <input type="text" class="form-control" name="LanguageSkills[${index}].Name" required/>
                    </div>
                    <div class="form-group">
                        <label>Listening</label>
                                <select class="form-control" name="LanguageSkills[${index}].Listening">${languageSkillOptionsHtml}</select>
                    </div>
                    <div class="form-group">
                        <label>Reading</label>
                                <select class="form-control" name="LanguageSkills[${index}].Reading">${languageSkillOptionsHtml}</select>
                    </div>
                    <div class="form-group">
                        <label>Speaking</label>
                                <select class="form-control" name="LanguageSkills[${index}].Speaking">${languageSkillOptionsHtml}</select>
                    </div>
                    <div class="form-group">
                        <label>Writing</label>
                                <select class="form-control" name="LanguageSkills[${index}].Writing">${languageSkillOptionsHtml}</select>
                    </div>
                    <button type="button" class="btn btn-danger btn-sm" onclick="removeEntry(this)">Remove</button>
                `;

    container.appendChild(newDiv);
});

function toggleEndDateForWork(endDateId, checkbox) {
    let endDateInput = document.getElementById(endDateId);
    endDateInput.disabled = checkbox.checked;

    if (checkbox.checked) {
        endDateInput.removeAttribute('required');
    } else {
        endDateInput.setAttribute('required', 'required');
    }
}

//For disabling or enabling enddate for education
function applyToggleLogic(educationStatusId, endDateId) {
    var educationStatus = document.getElementById(educationStatusId);
    var endDate = document.getElementById(endDateId);

    function toggleEndDate() {
        var isEndDateRequired = educationStatus.value == '0';
        endDate.disabled = !isEndDateRequired;

        if (isEndDateRequired) {
            endDate.setAttribute('required', 'required');
        } else {
            endDate.removeAttribute('required');
        }
    }

    toggleEndDate();
    educationStatus.addEventListener('change', toggleEndDate);
}

function removeEntry(element) {
    element.parentElement.remove();
}
