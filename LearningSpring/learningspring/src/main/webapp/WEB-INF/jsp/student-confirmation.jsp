<%-- <%@taglib  uri="http://java.sun.com/jsp/jstl/core" prefix="c" %> --%>
<html>
    <head>
        <title>Student Confirmation</title>
    </head>

    <body>
        <p>Student confirmed!</p>
        <p>${student.firstName} ${student.lastName} from ${student.country}, his
        favorite programming language is ${student.favoriteProgrammingLanguage}</p>

    <%--
        Operating systems preferred by the student:
    <ul>
        <c:forEach var="temp" items="${student.favoriteOS}">
            <li>${temp}</li>
        </c:forEach>
    </ul>
    --%>
    </body>
</html>