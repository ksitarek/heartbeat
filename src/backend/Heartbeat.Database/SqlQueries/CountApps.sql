SELECT COUNT(1) FROM "app" a
WHERE
    (@Search IS NULL OR (
        LOWER(a.label) LIKE LOWER(@Search) || '%'
        ))