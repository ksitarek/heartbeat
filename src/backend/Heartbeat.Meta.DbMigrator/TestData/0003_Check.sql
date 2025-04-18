INSERT INTO "check" ("id", "app_id", "label", "interval", "timeout",
                     "retries", "url", "port", "expected_response", "collect_response")
VALUES ('e1e3053e-3f71-4145-a230-48bb7bbfca37', 'c1a1f750-dc71-4b4d-914d-afe308f640e5', 'Homepage Check', '00:05:00',
        '00:00:30', 3, 'https://krystiansitarek.pl', 443, '200 OK', TRUE) ON CONFLICT ("id") DO NOTHING;