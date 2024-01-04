const countryDefaults = {
    preferredCountries: ['gb', 'fr'],
    onlyCountries: ['gb', 'fr', 'at', 'be', 'bg', 'cz', 'de', 'ee', 'ie', 'es', 'hr', 'it', 'cy', 'lv', 'lt', 'lu', 'hu', 'mt', 'nl', 'pl', 'pt', 'ro', 'si', 'sk', 'se', 'no', 'fi', 'is', 'li', 'ch', 'dk', 'gr', 'us', 'ky'],
    responsiveDropdown: true
};
const countryDefaultsWithMultiJurisdictional = {
    preferredCountries: ['gb', 'fr', 'zz'],
    onlyCountries: ['gb', 'fr', 'at', 'be', 'bg', 'cz', 'de', 'ee', 'ie', 'es', 'hr', 'it', 'cy', 'lv', 'lt', 'lu', 'hu', 'mt', 'nl', 'pl', 'pt', 'ro', 'si', 'sk', 'se', 'no', 'fi', 'is', 'li', 'ch', 'dk', 'gr', 'us', 'zz', 'ky'],
    responsiveDropdown: true
};

const getCountriesList = () => $.fn.countrySelect.getCountryData().filter(({ name, iso2 }) => countryDefaults.onlyCountries.includes(iso2));
const getCountriesListWithMultiJurisdictional = () => $.fn.countrySelect.getCountryData().filter(({ name, iso2 }) => countryDefaultsWithMultiJurisdictional.onlyCountries.includes(iso2));


function DisplayCountrySelection(elementidArray, selected_countries, countryList) {
    //countryList needs to be in the specific format of the used library

    elementidArray.forEach((id, index) => {
        countryList.forEach(country => {
            const { name } = country;
            let option = `<option value='${name}'>${name}</option>`;
            let simpleName = name.indexOf(' (') > 0 ? name.slice(0, name.indexOf(' (')) : name;
            if (selected_countries[index] != null && selected_countries[index].includes(simpleName))
                option = $(option).attr("selected", "selected");

            $('#' + id).append(option);
        })

    })

}