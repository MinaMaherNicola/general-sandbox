<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form"%>
<html>
    <head>
        <title>Student Form</title>
    </head>

    <body>
        <form:form action="processForm" modelAttribute="student">
            First name: <form:input path="firstName" />
            <br />
            Last name: <form:input path="lastName" />
            <br />
            Country: <form:select path="country">
                        <form:options items="${student.countryOptions}" />
                     </form:select>
            <br />
            <p>Favorite programming language:</p>
            Java <form:radiobutton path="favoriteProgrammingLanguage" value="Java" />
            C# <form:radiobutton path="favoriteProgrammingLanguage" value="C#" />
            C <form:radiobutton path="favoriteProgrammingLanguage" value="C" />
            <br />
            <p>Preferred operating system:</p>
            Linux <form:checkbox path="favoriteOS" value="linux" />
            MAC Os <form:checkbox path="favoriteOS" value="MAC Os" />
            Windows <form:checkbox path="favoriteOS" value="Windows" />
            <br />
            <input type="submit" value="Submit" />
        </form:form>
    </body>
</html>